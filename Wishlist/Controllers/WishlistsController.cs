using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Wishlist.Hubs;
using Wishlist.Services;

namespace Wishlist.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistsController : ControllerBase
    {
        private readonly IWishlistsService _wishlistsService;

        private readonly IHubContext<MessageHub> hub;

        public WishlistsController(IWishlistsService wishlistsService, IHubContext<MessageHub> hub)
        {
            _wishlistsService = wishlistsService;
            this.hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult> GetWishlistByUserAsync()
        {
            var wishlist = await _wishlistsService.GetWishlistByUserAsync();
            await hub.Clients.All.SendAsync("ReceiveMessage", "Hey! It seems like your wishlist is opened somewhere else.");
            return Ok(wishlist);
        }

        [HttpPost]
        public async Task<ActionResult> AddWishlistAsync()
        {
            await _wishlistsService.AddWishlistAsync();
            return NoContent();
        }

    }
}
