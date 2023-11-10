namespace CustomerMicroservice.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<String>? preferences { get; set; }

    }
}
