using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Models
{
    public class CustomerPreference
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string PreferenceName { get; set; }
        public Customer Customer { get; set; }
    }
}
