using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;
using Wishlist.ViewModels;

namespace Wishlist.Queries.Items
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemViewModel>>
    {

    }

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemViewModel>>
    {
        private readonly WishlistQueryContext _wishlistQueryContext;

        public GetAllItemsQueryHandler(WishlistQueryContext wishlistQueryContext)
        {
            _wishlistQueryContext = wishlistQueryContext;
        }

        public async Task<IEnumerable<ItemViewModel>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _wishlistQueryContext
                .Items
                .ToListAsync(cancellationToken);

            return from item in items
                   select new ItemViewModel
                   {
                       Id = item.Id,
                       Name = item.Name,
                       Description = item.Description
                   };
        }
    }
}
