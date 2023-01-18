using AutoMapper;
using Core.Domain;

namespace WebApi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, PackageDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PickUp, opt => opt.MapFrom(src => src.PickUp))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Meal, opt => opt.MapFrom(src => src.Meal))
                .ForMember(dest => dest.AvailableUntil, opt => opt.MapFrom(src => src.AvailableUntil))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<Product, ProductDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(dto => dto.ContainsAlcohol, opt => opt.MapFrom(p => p.ContainsAlcohol))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(p => p.Image));

            CreateMap<Student, StudentDTO>();
        }
    }
}
