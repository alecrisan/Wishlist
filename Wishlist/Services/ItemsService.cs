using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Wishlist.Commands;
using Wishlist.Queries.Items;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IMediator _mediator;

        public ItemsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IEnumerable<ItemViewModel>> GetAllAsync()
            => _mediator.Send(new GetAllItemsQuery());

        public Task AddItemAsync(ItemViewModel viewModel)
            => _mediator.Send(new AddItemCommand
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            });

        public Task EditItemAsync(ItemViewModel viewModel)
            => _mediator.Send(new EditItemCommand
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            });

        public Task DeleteItemAsync(int id)
            => _mediator.Send(new DeleteItemCommand
            {
                Id = id
            });
    }
}
