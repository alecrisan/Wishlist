using System.Collections.Generic;
using System.Threading.Tasks;
using Wishlist.ViewModels;

namespace Wishlist.Services
{
    public interface IQAsService
    {
        Task<IEnumerable<QAViewModel>> GetAllQAsByCategoryAsync(int categoryId);
    }
}
