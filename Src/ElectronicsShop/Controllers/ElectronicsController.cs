using ElectronicsShop.Application.Categories.Queries.GetCategories;
using ElectronicsShop.Application.Orders.Commands.Order;
using ElectronicsShop.Application.Products.Queries.GetProductById;
using ElectronicsShop.Application.Products.Queries.GetProducts;
using ElectronicsShop.Application.Users.Commands.Login;
using ElectronicsShop.Application.Users.Commands.Register;
using ElectronicsShop.Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsShop.Presentation.Controllers
{
    public class ElectronicsController : BaseController
    {
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new RegisterCommand
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    BirthDate = user.BirthDate,
                    Password = user.Password
                });

                return RedirectToAction("Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var loginOutput = await Mediator.Send(new LoginCommand
            {
                Email = email,
                Password = password
            });

            HttpContext.Session.SetString("UserId", loginOutput.User.Id.ToString());
            HttpContext.Session.SetString("UserName", loginOutput.User.UserName);
            HttpContext.Session.SetString("RoleId", loginOutput.User.UserRoles.FirstOrDefault().RoleId.ToString());

            return Json(loginOutput.Status);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            return Json(true);
        }

        [HttpGet]
        public async Task<ActionResult> CategoriesMenu()
        {
            var output = await Mediator.Send(new GetCategoriesQuery());

            var categories = output.Categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.Products.Select(p => new ProductVM
                {
                    Name = p.Name
                })
            }).ToList();

            return PartialView("_CategoriesMenu", categories);
        }

        public async Task<IActionResult> Home(int categoryId)
        {
            var output = await Mediator.Send(new GetProductsQuery { 
                CategoryId = categoryId
            });

            var productsListVM = new ProductsListVM { 
                Products = output.Products.Select(product => new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    AvailableQuantity = product.AvailableQuantity
                })
            };

            return View(productsListVM);
        }

        public async Task<IActionResult> Order(int productId)
        {
            var output = await Mediator.Send(new GetProductByIdQuery
            {
                Id = productId
            });

            var product = new ProductVM
            {
                Id = output.Product.Id,
                Name = output.Product.Name,
                Description = output.Product.Description,
                Price = output.Product.Price,
                AvailableQuantity = output.Product.AvailableQuantity
            };

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Order(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                await Mediator.Send(new OrderCommand
                {
                    ProductId = product.Id,
                    Quantity = product.Quantity,
                    UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"))
                });

                return RedirectToAction("Home");
            }

            return View();
        }
    }
}
