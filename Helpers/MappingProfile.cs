using AutoMapper;
using EntryForm.Dtos;
using EntryForm.Models;

namespace EntryForm.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(src => src.Photo, opt => opt.Ignore());
        }

    }
}
