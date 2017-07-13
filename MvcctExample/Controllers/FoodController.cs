using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MvcControlsToolkit.Controllers;
using MvcControlsToolkit.Core.OData;
using MvcctExample.DTOs;
using MvcctExample.Repositories;
using MvcctExample.ViewModels;
namespace MvcctExample.Controllers
{
    public class FoodController : 
        ServerCrudController<FoodDTO, FoodDTO, int?>
    {
        public IWebQueryProvider queryProvider { get; private set; }
        public FoodController(FoodRepository repository,
            IStringLocalizerFactory factory, 
            IHttpContextAccessor accessor,
            IWebQueryProvider queryProvider) 
            : base(factory, accessor)
        {
            Repository = repository;
            this.queryProvider = queryProvider;
        }
        // GET: Food
        [ResponseCache(Duration = 0, NoStore = true)]
        public async Task<ActionResult> Index()
        {
            var query = queryProvider.Parse<FoodDTO>();

            int pg = (int)query.Page;
            var grouping = query.GetGrouping<FoodDTOGrouping>();

            var model = new FoodListViewModel
            {
                Query = query,
                Products =
                    grouping == null ?
                        await Repository.GetPage(
                            query.GetFilterExpression(),
                            query.GetSorting() ??
                                (q => q.OrderBy(m => m.ProductName)),
                            pg, 5)
                        :
                        await Repository.GetPageExtended(
                            query.GetFilterExpression(),
                            query.GetSorting<FoodDTOGrouping>() ??
                                (q => q.OrderBy(m => m.ProductName)),
                            pg, 5,
                            query.GetGrouping<FoodDTOGrouping>())
            };

            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> GetSuppliers(string search)
        {
            var res = search == null || search.Length < 3 ?
                new List<AutoCompleteItem>() :
                await (Repository as FoodRepository).GetSuppliers(search, 10);
            return Json(res);
        }

    }
}