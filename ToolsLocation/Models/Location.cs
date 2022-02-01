using System.ComponentModel.DataAnnotations;

namespace ToolsLocation.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Only one character.")] 
        public string ShelfName { get; set; }
        [Required]
        [Range(0, 4,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ShelfFloor { get; set; }
    }
}
