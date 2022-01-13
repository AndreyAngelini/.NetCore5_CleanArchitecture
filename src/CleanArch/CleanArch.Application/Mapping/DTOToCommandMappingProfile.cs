using AutoMapper;
using CleanArch.Application.DTO;
using CleanArch.Application.CQRS.Products;
using CleanArch.Application.CQRS.Products.Commands;

namespace CleanArch.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
