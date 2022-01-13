using System.Collections.Generic;

namespace Wishlist.ViewModels
{
    public class WishlistViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ICollection<ItemViewModel> Items { get; set; }
    }
}
