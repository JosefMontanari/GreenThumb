using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        [Column("id")]
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public List<InstructionModel> Instructions { get; set; } = new();

    }
}
