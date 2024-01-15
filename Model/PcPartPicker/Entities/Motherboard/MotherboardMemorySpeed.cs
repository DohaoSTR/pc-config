using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_memory_speed")]
    public class MotherboardMemorySpeed
    {
        [Key]
        public int Id { get; set; }

        [Column("memory_type")]
        public string MemoryType { get; set; }

        [Column("memory_speed")]
        public int MemorySpeed { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
