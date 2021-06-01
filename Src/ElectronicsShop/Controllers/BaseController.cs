using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicsShop.Presentation.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();
    }
}
