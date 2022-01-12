using System.Threading;
using System.Threading.Tasks;
using MediatR;
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

        public AddItemCommandHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            _applicationDbContext.Items.Add(
                new Models.Item
                {
                    Name = request.Name,
                    Description = request.Description
                }
            );

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}