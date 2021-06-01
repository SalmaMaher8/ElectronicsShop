using AutoMapper;
using ElectronicsShop.Domain.Models;
using ElectronicsShop.Presentation.ViewModels;

namespace ElectronicsShop.Presentation.Mappings
{
    public class PresentationAutoMapperConfigurations : Profile
    {
        public PresentationAutoMapperConfigurations()
        {
            CreateMap<ProductVM, Product>().ReverseMap();
        }
    }
}
