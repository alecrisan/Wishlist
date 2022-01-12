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
    }
}
