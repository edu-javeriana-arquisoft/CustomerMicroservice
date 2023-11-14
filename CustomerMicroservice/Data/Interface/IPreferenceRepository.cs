namespace CustomerMicroservice.Data.Interface
{
    public interface IPreferenceRepository
    {
        Task<Preference> GetPreferenceByName(string name);
    }
}
