using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcControlsToolkit.Core.Business.Utilities;
using MvcctExample.Data;
using MvcctExample.Models;
using MvcctExample.DTOs;
using Microsoft.EntityFrameworkCore;
namespace MvcctExample.Repositories
{
    public class FoodRepository : 
        DefaultCRUDRepository<ApplicationDbContext, Food>
    {
        private ApplicationDbContext db;
        public  FoodRepository(ApplicationDbContext db):
            base(db, db.Foods)
        {
            this.db = db;
        }
        public async Task<IEnumerable<AutoCompleteItem>> 
            GetSuppliers(string search, int maxitems)
        {
            return await db.Suppliers.Where(m => m.CompanyName.StartsWith(search))
                .Take(maxitems)
                .Select(m => new AutoCompleteItem
                {
                    Display = m.CompanyName,
                    Value = m.Id
                }).ToArrayAsync();
        }  
    }
}
