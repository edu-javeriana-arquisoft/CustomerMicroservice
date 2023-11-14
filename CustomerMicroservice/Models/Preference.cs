namespace CustomerMicroservice.Models
{
    [Table("Preference")]
    public class Preference
    {

        [Key]
        public int Id { get; set; }
        [Required]

        public string PreferenceName { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
