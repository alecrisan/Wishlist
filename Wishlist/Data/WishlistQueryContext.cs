using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wishlist.Models;

namespace Wishlist.Data
{
    public class WishlistQueryContext : IWishlistQueryContext
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WishlistQueryContext(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<Item> Items
            => _applicationDbContext.Items
                .AsNoTracking();

        public IQueryable<QA> QAs
            => _applicationDbContext.QAs
                .AsNoTracking();

        public IQueryable<ApplicationUser> Users
            => _applicationDbContext.Users
               .AsNoTracking();

        public IQueryable<Wishlist.Models.Wishlist> Wishlists
            => _applicationDbContext.Wishlists
                .Include(x => x.Items)
               .AsNoTracking();
    }
}
