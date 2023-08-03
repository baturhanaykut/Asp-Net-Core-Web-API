using AutoMapper;
using Nlayer.Core.DTOs;
using Nlayer.Core.Entities;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(product);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
