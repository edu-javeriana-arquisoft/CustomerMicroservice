using AutoMapper;

namespace CustomerMicroservice.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() { 
            CreateMap<CustomerDTO,Customer>();
            CreateMap<Customer,CustomerDTO>().IncludeMembers(e => e.Preferences);

            CreateMap<Preference, PreferenceDTO>().IncludeMembers(e => e.Customers);
            CreateMap<PreferenceDTO, Preference>();
        }
    }
}
