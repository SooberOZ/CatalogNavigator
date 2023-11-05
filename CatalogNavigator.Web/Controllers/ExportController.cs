using CatalogNavigator.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CatalogNavigator.Web.Controllers
{
    [Route("export")]
    public class ExportController : Controller
    {
        private readonly CatalogDB _context;

        public ExportController(CatalogDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Export()
        {
            var catalogs = await _context.Catalogs.ToListAsync();

            var jsonString = JsonConvert.SerializeObject(catalogs);
            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
            var stream = new MemoryStream(bytes);

            return File(stream, "application/json", "catalogs.json");
        }
    }
}