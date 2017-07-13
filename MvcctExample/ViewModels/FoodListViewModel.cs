using MvcControlsToolkit.Core.Business.Utilities;
using MvcControlsToolkit.Core.Views;
using MvcctExample.DTOs;

namespace MvcctExample.ViewModels
{
    public class FoodListViewModel
    {
        public DataPage<FoodDTO> Products { get; set; }
        public QueryDescription Query { get; set; }
    }
}
