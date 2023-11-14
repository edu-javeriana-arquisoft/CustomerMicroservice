namespace CustomerMicroservice.Service.Interfaces
{
    public interface IPreferenceService
    {
        Task<Preference> AddPreference(PreferenceDTO preferenceDTO);
        Task<Preference> GetPreferenceByName(string name);
    }
}
