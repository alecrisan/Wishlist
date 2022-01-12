using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;
using Wishlist.ViewModels;

namespace Wishlist.Queries.QAs
{
    public class GetAllQAsByCategoryQuery : IRequest<IEnumerable<QAViewModel>>
    {
        public int CategoryId { get; set; }

        public GetAllQAsByCategoryQuery(int id)
        {
            CategoryId = id;
        }
    }

    public class GetAllQAsByCategoryQueryHandler : IRequestHandler<GetAllQAsByCategoryQuery, IEnumerable<QAViewModel>>
    {
        private readonly WishlistQueryContext _wishlistQueryContext;

        public GetAllQAsByCategoryQueryHandler(WishlistQueryContext wishlistQueryContext)
        {
            _wishlistQueryContext = wishlistQueryContext;
        }

        public async Task<IEnumerable<QAViewModel>> Handle(GetAllQAsByCategoryQuery request, CancellationToken cancellationToken)
        {

            var qas = await _wishlistQueryContext
                .QAs
                .Where(x => (int)x.Category == request.CategoryId)
                .ToListAsync(cancellationToken);

            return from qa in qas
                   select new QAViewModel
                   {
                       Id = qa.Id,
                       Question = qa.Question,
                       Answer = qa.Answer
                   };
        }
    }
}
