using CustomerMicroservice.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Data.Repository
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Preference> _preferences;
        public PreferenceRepository(ApplicationDbContext context)
        {
            
            _context = context;
            _preferences = context.Preferences;
        }
        public async Task<Preference> GetPreferenceByName(string name)
        {
            var preference = _context.Preferences.FirstOrDefault(p => p.PreferenceName == name);
            return preference;
        }
    }
}
