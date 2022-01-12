using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models
{
    public enum HelpCategory
    {
        General,
        Items,
        Other
    }

    public class QA
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Question { get; set; }

        [Required]
        [MaxLength(255)]
        public string Answer { get; set; }

        [Required]
        [EnumDataType(typeof(HelpCategory))]
        public HelpCategory Category { get; set; }
    }
}
