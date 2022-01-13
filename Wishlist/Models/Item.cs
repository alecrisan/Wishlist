using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public Wishlist Wishlist { get; set; }
    }
}
