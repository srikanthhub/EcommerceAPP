using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using MVCWebApp.Services;

namespace MVCWebApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;    
        }
        public async Task<IActionResult> Index()
        {
            var items = await _catalogService.GetCatalogItems();
            return View(items);
        }

        // GET: Catalog/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CatalogItem item = await _catalogService.GetItemDetails(id);
            return View(item);
        }
    }
}
