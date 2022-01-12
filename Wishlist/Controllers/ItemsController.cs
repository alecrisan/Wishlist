using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Services;
using Wishlist.ViewModels;

namespace Wishlist.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var items = await _itemsService.GetAllAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> AddItemAsync(ItemViewModel itemViewModel)
        {
            await _itemsService.AddItemAsync(itemViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(int id)
        {
            await _itemsService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
