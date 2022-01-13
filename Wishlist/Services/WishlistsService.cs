using System.Threading.Tasks;
using MediatR;
using Wishlist.Commands;
using Wishlist.Queries.Wishlist;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public class WishlistsService : IWishlistsService
    {
        private readonly IMediator _mediator;

        public WishlistsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<WishlistViewModel> GetWishlistByUserAsync()
           => _mediator.Send(new GetWishlistByUserQuery());

        public Task AddWishlistAsync()
            => _mediator.Send(new AddWishlistCommand());
    }
}
