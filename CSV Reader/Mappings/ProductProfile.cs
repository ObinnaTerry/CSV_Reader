using AutoMapper;
using CSV_Reader.Entities;
using CSV_Reader.Models;

namespace CSV_Reader.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Product>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
