using System.Collections.Generic;
using System.Threading.Tasks;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemViewModel>> GetAllAsync();

        Task AddItemAsync(ItemViewModel viewModel);

        Task DeleteItemAsync(int id);
    }
}
