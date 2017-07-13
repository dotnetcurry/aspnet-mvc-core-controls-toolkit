using System.ComponentModel.DataAnnotations;
using MvcControlsToolkit.Core.DataAnnotations;
namespace MvcctExample.DTOs
{
    public class FoodDTO
    {
        public int? Id { get; set; }
        [Query, StringLength(64, MinimumLength = 2), Required, 
            Display(Name ="name")]
        public string ProductName { get; set; }
        [Query, StringLength(32, MinimumLength = 2), Required,
            Display(Name = "package type")]
        public string Package { get; set; }
        [Query,
            Display(Name = "unit price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "discontinued")]
        public bool IsDiscontinued { get; set; }
        [Query,
            Display(Name = "supplier")]
        public int SupplierId { get; set; }
        [Query,
            Display(Name = "supplier")]
        public string SupplierCompanyName { get; set; }
    }
    [RunTimeType]
    public class FoodDTOGrouping : FoodDTO
    {
        public int SupplierIdCount { get; set; }
        public int PackageCount { get; set; }
    }
}
