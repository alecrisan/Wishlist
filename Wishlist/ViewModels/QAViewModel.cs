using System.ComponentModel.DataAnnotations;
using Wishlist.Models;

namespace Wishlist.ViewModels
{
    public class QAViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Question { get; set; }

        [Required, MaxLength(255)]
        public string Answer { get; set; }

        [EnumDataType(typeof(HelpCategory))]
        public HelpCategory HelpCategory { get; set; }
    }
}
