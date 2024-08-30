using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [Range(0.01 ,1000.000)]
        public decimal Price { get; set; }
    }
}
