using System.ComponentModel.DataAnnotations;
namespace MvcctExample.Models
{
    public class Food
    {
        public int Id { get; set; }
        [MaxLength(64), Required]
        public string ProductName { get; set; }
        [MaxLength(32), Required]
        public string Package { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscontinued { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } 
    }
}
