using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Data;

namespace Wishlist.Commands
{
    public class EditItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class EditItemCommandHandler : AsyncRequestHandler<EditItemCommand>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EditItemCommandHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(EditItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _applicationDbContext
                .Items
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item != null)
            {
                item.Name = request.Name;
                item.Description = request.Description;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
