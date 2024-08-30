using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string  Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
