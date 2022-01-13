using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;
using Wishlist.Models;
using Wishlist.ViewModels;

namespace Wishlist.Queries.Wishlist
{
    public class GetWishlistByUserQuery : IRequest<WishlistViewModel>
    {

    }

    public class GetWishlistByUserQueryHandler : IRequestHandler<GetWishlistByUserQuery, WishlistViewModel>
    {
        private readonly WishlistQueryContext _wishlistQueryContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetWishlistByUserQueryHandler(WishlistQueryContext wishlistQueryContext, IHttpContextAccessor contextAccessor)
        {
            _wishlistQueryContext = wishlistQueryContext;
            _httpContextAccessor = contextAccessor;
        }

        public async Task<WishlistViewModel> Handle(GetWishlistByUserQuery request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _wishlistQueryContext.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

            var wishlist = _wishlistQueryContext
                .Wishlists.Include(w => w.Items)
                .AsEnumerable()
                .Where(w => w.UserId == user.Id)
                .LastOrDefault();

            if (wishlist != null)
            {
                var items = _wishlistQueryContext.Items.Where(i => i.Wishlist.Id == wishlist.Id).ToList();

                return new WishlistViewModel
                {
                    Id = wishlist.Id,
                    UserId = wishlist.UserId,
                    Items = GetItemViewModels(items)
                };
            }
            return new WishlistViewModel();
        }

        private ICollection<ItemViewModel> GetItemViewModels(ICollection<Item> items)
        {
            List<ItemViewModel> result = new List<ItemViewModel>();

            foreach (var item in items)
            {
                var itemVM = new ItemViewModel();
                itemVM.Id = item.Id;
                itemVM.Name = item.Name;
                itemVM.Description = item.Description;

                result.Add(itemVM);
            }

            return result;
        }
    }
}
