using System.Threading.Tasks;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public interface IWishlistsService
    {
        Task<WishlistViewModel> GetWishlistByUserAsync();
    }
}
