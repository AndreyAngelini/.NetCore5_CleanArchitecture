using CleanArch.Domain.Entity;
using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.CQRS.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
