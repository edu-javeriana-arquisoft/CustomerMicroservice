using System.Text.Json.Serialization;

namespace CustomerMicroservice.Models
{
    [Table("Customer")]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public List<Preference> Preferences { get; set; } = new List<Preference>();


    }
}
