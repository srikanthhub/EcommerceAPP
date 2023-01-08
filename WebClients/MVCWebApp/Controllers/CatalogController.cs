using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var items = _catalogService.GetCatalogItems();
            return View(items);
        }
    }
}
