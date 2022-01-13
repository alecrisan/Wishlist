using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Services;

namespace Wishlist.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistsController : ControllerBase
    {
        private readonly IWishlistsService _wishlistsService;

        public WishlistsController(IWishlistsService wishlistsService)
        {
            _wishlistsService = wishlistsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetWishlistByUserAsync()
        {
            var wishlist = await _wishlistsService.GetWishlistByUserAsync();
            return Ok(wishlist);
        }
    }
}
