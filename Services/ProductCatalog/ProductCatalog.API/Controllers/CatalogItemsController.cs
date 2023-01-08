using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObject;
using ProductCatalog.Domain;
using ProductCatalog.EFRepositories;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly ICatalogItemBO _catalogItemBO;

        public CatalogItemsController(ICatalogItemBO catalogItemBO)
        {
            _catalogItemBO = catalogItemBO;
        }

        // GET: api/CatalogItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItem()
        {
            var items = await _catalogItemBO.GetCatalogItems();
            return Ok(items);
        }

        // GET: api/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItem(int id)
        {
            var catalogItem = await _catalogItemBO.GetCatalogItemDetails(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            return catalogItem;
        }

        // PUT: api/CatalogItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogItem(int id, CatalogItem catalogItem)
        {
            if (id != catalogItem.Id)
            {
                return BadRequest();
            }



            try
            {
                await _catalogItemBO.Update(catalogItem);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return NoContent();
        }

        // POST: api/CatalogItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogItem>> PostCatalogItem(CatalogItem catalogItem)
        {

            var item = await _catalogItemBO.Add(catalogItem);
            return CreatedAtAction("GetCatalogItem", new { id = catalogItem.Id }, item);
        }

        // DELETE: api/CatalogItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogItem(int id)
        {
            await _catalogItemBO.Delete(id);

            return NoContent();
        }

    }
}
