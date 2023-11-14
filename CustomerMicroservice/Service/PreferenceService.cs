using AutoMapper;
using CustomerMicroservice.Service.Interfaces;

namespace CustomerMicroservice.Service
{
    public class PreferenceService : IPreferenceService
    {
        private readonly PreferenceRepository _preferenceRepository;
       
        private readonly IMapper _mapper;
        public PreferenceService(PreferenceRepository preferenceRepository, IMapper mapper)
        {
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }

        public Task<Preference> AddPreference(PreferenceDTO preferenceDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Preference> GetPreferenceByName(string name)
        {
            return _preferenceRepository.GetPreferenceByName(name);
        }
    }
}
