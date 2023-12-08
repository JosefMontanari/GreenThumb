using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        [Column("id")]
        public int InstructionId { get; set; }
        public string Instruction { get; set; } = null!;
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;


    }
}
