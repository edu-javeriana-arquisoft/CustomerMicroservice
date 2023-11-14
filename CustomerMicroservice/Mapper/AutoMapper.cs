using AutoMapper;

namespace CustomerMicroservice.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {

            CreateMap<Customer, CustomerDTO>()
             .ForMember(dest => dest.CustomerPreferences, opt => opt.MapFrom(src => src.Preferences.Select(p => p.PreferenceName).ToList()));
            CreateMap<CustomerDTO, Customer>()
            .ForMember(dest => dest.Preferences, opt => opt.MapFrom(src => src.CustomerPreferences.Select(p => new Preference { PreferenceName = p }).ToList()));
        }
    }
}
