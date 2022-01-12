using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;

namespace Wishlist.Commands
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteItemCommandHandler : AsyncRequestHandler<DeleteItemCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DeleteItemCommandHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _applicationDbContext
                .Items
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item != null)
            {
                _applicationDbContext.Items.Remove(item);

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
