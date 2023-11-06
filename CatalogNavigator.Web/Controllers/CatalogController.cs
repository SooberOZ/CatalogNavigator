using CatalogNavigator.DataLayer;
using CatalogNavigator.DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogNavigator.Web.Controllers
{
    [Route("Catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogDB _context;

        public CatalogController(CatalogDB context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var rootCatalog = _context.Catalogs
             .Include(c => c.SubCatalogs)
             .FirstOrDefault(c => c.ParentId == null);

            return View(rootCatalog);
        }

        [HttpGet("ShowSubCatalogs/{catalogId}")]
        public IActionResult ShowSubCatalogs(int catalogId)
        {
            var subCatalogs = _context.Catalogs.Where(c => c.ParentId == catalogId).ToList();
            return View(subCatalogs);
        }

        [HttpGet("ShowImportedCatalogs")]
        public IActionResult ShowImportedCatalogs(List<Catalog> importedCatalogs)
        {
            return View(importedCatalogs);
        }
    }
}