using AutoMapper;
using CustomerMicroservice.Service.Interfaces;

namespace CustomerMicroservice.Service
{
    public class PreferenceService : IPreferenceService
    {
        private readonly PreferenceRepository _preferenceRepository;
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        public PreferenceService(PreferenceRepository preferenceRepository, IMapper mapper)
        {
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }
        public async Task<Preference> AddPreference(PreferenceDTO preferenceDTO, String customerId)
        {
            var preference = _mapper.Map<Preference>(preferenceDTO);
            preference.Customers.Add(_customerService.get)
            await _preferenceRepository.AddPreference(preference);
            return preference;
        }

        public Task<Preference> GetPreferenceById(int id)
        {
            return _preferenceRepository.GetPreferenceById(id);
        }

        public async Task<Preference> GetPreferenceByName(string name)
        {
            return await _preferenceRepository.GetPreferenceByName(name);
        }
    }
}
