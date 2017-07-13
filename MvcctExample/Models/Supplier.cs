using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MvcctExample.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [MaxLength(64), Required]
        public string CompanyName { get; set; }
        [MaxLength(128), Required]
        public string ContactName { get; set; }
        [MaxLength(64)]
        public string ContactTitle { get; set; }
        [MaxLength(64), Required]
        public string City { get; set; }
        [MaxLength(64), Required]
        public string Country { get; set; }
        [MaxLength(32), Required]
        public string Phone { get; set; }
        [MaxLength(32)]
        public string Fax { get; set; }
        public virtual ICollection<Food> Products { get; set; }
    }
}
