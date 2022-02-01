using System.ComponentModel.DataAnnotations;

namespace ToolsLocation.Models
{
    public class Tool
    {
        public int ToolId { get; set; }
        [Required]
        public string Name { get; set; } = "Battery Drill";
        public string Brand { get; set; } = "brand";
        public string Model { get; set; } = "model";

        public int LocationId { get; set; }
        public Location Location { get; set; }        

    }
}
