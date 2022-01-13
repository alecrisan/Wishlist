using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;

namespace Wishlist.Commands
{
    public class AddItemCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class AddItemCommandHandler : AsyncRequestHandler<AddItemCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly WishlistQueryContext _wishlistQueryContext;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddItemCommandHandler(ApplicationDbContext applicationDbContext, WishlistQueryContext wishlistQueryContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _wishlistQueryContext = wishlistQueryContext;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _wishlistQueryContext.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();

            var wishlist = _applicationDbContext.Wishlists.Where(w => w.UserId == user.Id).FirstOrDefaultAsync();

            _applicationDbContext.Items.Add(
                new Models.Item
                {
                    Name = request.Name,
                    Description = request.Description,
                    Wishlist = await wishlist
                }
            );

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}