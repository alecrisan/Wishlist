using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;

namespace Wishlist.Commands
{
    public class AddWishlistCommand : IRequest
    {

    }

    public class AddWishlistCommandHandler : AsyncRequestHandler<AddWishlistCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly WishlistQueryContext _wishlistQueryContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddWishlistCommandHandler(ApplicationDbContext applicationDbContext, IHttpContextAccessor contextAccessor, WishlistQueryContext wishlistQueryContext)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = contextAccessor;
            _wishlistQueryContext = wishlistQueryContext;

        }

        protected override async Task Handle(AddWishlistCommand request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _wishlistQueryContext.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

            var userWishlist = _wishlistQueryContext
                .Wishlists
                .AsEnumerable()
                .Where(c => c.UserId == user.Id)
                .LastOrDefault();

            if (user != null && userWishlist == null)
            {
                _applicationDbContext.Wishlists.Add(new Models.Wishlist
                {
                    UserId = user.Id
                });

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
