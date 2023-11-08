using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMicroservice.Model
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
