using ElectronicsShop.Application.Categories.Queries.GetCategories.Dtos;
using ElectronicsShop.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Categories.Queries.GetCategories
{
    class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesOutput>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoriesOutput> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return new GetCategoriesOutput {
                Categories = categories
            };
        }
    }
}
