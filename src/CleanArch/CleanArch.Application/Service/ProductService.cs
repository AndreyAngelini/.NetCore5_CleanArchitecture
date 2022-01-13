using AutoMapper;
using CleanArch.Application.CQRS.Products.Commands;
using CleanArch.Application.CQRS.Products.Queries;
using CleanArch.Application.DTO;
using CleanArch.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception($"Entity could not loaded.");

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productsByIdQuery = new GetProductByIdQuery(id.Value);
            if (productsByIdQuery == null)
                throw new Exception($"Entity could not loaded.");

            var result = await _mediator.Send(productsByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task AddAsync(ProductDTO DTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(DTO);
            if (productCreateCommand == null)
                throw new Exception($"Entity could not loaded.");

            await _mediator.Send(productCreateCommand);
        }


        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO DTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(DTO);
            if (productUpdateCommand == null)
                throw new Exception($"Entity could not loaded.");

            await _mediator.Send(productUpdateCommand);
        }
    }
}
