using CleanArch.Application.CQRS.Products.Queries;
using CleanArch.Domain.Entity;
using CleanArch.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.CQRS.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
