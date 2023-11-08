﻿
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }
        public virtual ICollection<CustomerPreference> CustomerPreference 
        {
            get;
            set;
        } = new List<CustomerPreference>();
    }
}
