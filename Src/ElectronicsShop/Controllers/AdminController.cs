using ElectronicsShop.Application.Categories.Queries.GetCategories;
using ElectronicsShop.Application.Orders.Queries.GetOrders;
using ElectronicsShop.Application.Products.Commands.AddProduct;
using ElectronicsShop.Application.Products.Commands.ApplyDiscount;
using ElectronicsShop.Application.Products.Queries.GetProductById;
using ElectronicsShop.Application.Products.Queries.GetProducts;
using ElectronicsShop.Application.Users.Commands.AdminLogin;
using ElectronicsShop.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsShop.Presentation.Controllers
{
    public class AdminController : BaseController
    {
        public async Task<IActionResult> ProductsList()
        {
            var products = await Mediator.Send(new GetProductsQuery());

            var productsVM = products.Products.Select(product => new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AvailableQuantity = product.AvailableQuantity,
            });

            return View(productsVM);
        }

        public async Task<IActionResult> AddProduct()
        {
            var output = await Mediator.Send(new GetCategoriesQuery());

            ViewBag.Categories = new SelectList(output.Categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new AddProductCommand {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    AvailableQuantity = product.AvailableQuantity,
                    CategoryId = product.CategoryId,
                    CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("AdminId"))
                });

                return RedirectToAction("ProductsList");
            }

            var output = await Mediator.Send(new GetCategoriesQuery());

            ViewBag.Categories = new SelectList(output.Categories, "Id", "Name");

            return View();
        }

        public async Task<IActionResult> ApplyProductDiscount(int productId)
        {
            var output = await Mediator.Send(new GetProductByIdQuery { Id = productId });

            var productDiscount = new ProductDiscountVM { 
                ProductId = productId,
                ProductName = output.Product.Name
            };

            return View(productDiscount);
        }


        [HttpPost]
        public async Task<IActionResult> ApplyProductDiscount(ProductDiscountVM productDiscount)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new ApplyDiscountCommand
                {
                    ProductId = productDiscount.ProductId,
                    ConditionQuantity = productDiscount.ConditionQuantity,
                    Type = productDiscount.Type,
                    Value = productDiscount.Value,
                    ValidUntil = productDiscount.ValidUntil
                });

                return RedirectToAction("ProductsList");
            }

            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLogin)
        {
            if (ModelState.IsValid)
            {
                var loginOutput = await Mediator.Send(new AdminLoginCommand
                {
                    Email = adminLogin.Email,
                    Password = adminLogin.Password
                });

                HttpContext.Session.SetString("AdminId", loginOutput.User.Id.ToString());
                HttpContext.Session.SetString("AdminName", loginOutput.User.UserName);
                HttpContext.Session.SetString("RoleId", loginOutput.User.UserRoles.FirstOrDefault().RoleId.ToString());

                return RedirectToAction("ProductsList");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> OrdersList()
        {
            var output = await Mediator.Send(new GetOrdersQuery());

            var orders = output.Orders.Select(order => new OrderVM { 
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                User = new UserVM { 
                    FullName = order.User.FullName
                },
                OrderDetails = order.OrderDetails.Select(orderDetail => new OrderDetailVM { 
                    Quantity = orderDetail.Quantity,
                    Product = new ProductVM { 
                        Name = orderDetail.Product.Name
                    }
                })
            });

            return View(orders);
        }
    }
}
