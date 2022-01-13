using CleanArch.Domain.Entity;
using MediatR;

namespace CleanArch.Application.CQRS.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
