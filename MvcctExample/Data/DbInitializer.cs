using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
namespace MvcctExample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, 
            IHostingEnvironment hostingEnvironment)
        {
            context.Database.Migrate();
            var scriptsDir = Path.
                Combine(hostingEnvironment.ContentRootPath, "SqlScripts");
            if (!context.Suppliers.Any())
            {
                context.Database
                    .ExecuteSqlCommand(File.ReadAllText(
                        Path.Combine(scriptsDir, "Products.sql")));
            }
        }
    }
}
