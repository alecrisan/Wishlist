using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Wishlist.Queries.QAs;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public class QAsService : IQAsService
    {
        private readonly IMediator _mediator;

        public QAsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IEnumerable<QAViewModel>> GetAllQAsByCategoryAsync(int categoryId)
            => _mediator.Send(new GetAllQAsByCategoryQuery(categoryId));
    }
}
