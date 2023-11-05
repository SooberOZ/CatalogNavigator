using CatalogNavigator.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogNavigator.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogDB _context;

        public CatalogController(CatalogDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rootCatalog = _context.Catalogs
             .Include(c => c.SubCatalogs)
             .FirstOrDefault(c => c.ParentId == null);

            return View(rootCatalog);
        }

        public IActionResult ShowSubCatalogs(int catalogId)
        {
            var subCatalogs = _context.Catalogs.Where(c => c.ParentId == catalogId).ToList();
            return View(subCatalogs);
        }
    }
}