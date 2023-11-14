namespace CustomerMicroservice.Service.Interfaces
{
    public interface IPreferenceService
    {
        Task<Preference> AddPreference(PreferenceDTO preferenceDTO);

    }
}
