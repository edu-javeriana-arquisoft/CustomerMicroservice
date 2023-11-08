using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Models
{
    public class CustomerPreference
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string PreferenceName { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
