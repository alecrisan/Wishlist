using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
