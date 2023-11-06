using CatalogNavigator.DataLayer;
using CatalogNavigator.DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogNavigator.Web.Controllers
{
    [Route("import")]
    public class ImportController : Controller
    {
        private readonly CatalogDB _context;

        public ImportController(CatalogDB context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Отобразить страницу с формой импорта
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("File", "Please select a file.");
                return View("Index");
            }

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                var jsonString = await streamReader.ReadToEndAsync();
                var importedCatalogs = JsonConvert.DeserializeObject<List<Catalog>>(jsonString);

                return RedirectToAction("Index");
            }
        }
    }
}