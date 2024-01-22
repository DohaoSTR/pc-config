using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Memory
{
    [Table("memory_characteristics")]
    public class MemoryCharacteristics
    {
        [Key]
        public int Id { get; set; }

        [Column("memory_speed")]
        public int? MemorySpeed { get; set; }

        [Column("memory_type")]
        public string? MemoryType { get; set; }

        [Column("pin_count")]
        public int? PinCount { get; set; }

        [Column("memory_form_factor")]
        public string? MemoryFormFactor { get; set; }

        [Column("modules_count")]
        public int? ModulesCount { get; set; }

        [Column("modules_memory")]
        public int? ModulesMemory { get; set; }

        [Column("modules_memory_measure")]
        public string? ModulesMemoryMeasure { get; set; }

        [Column("first_word_latency")]
        public double? FirstWordLatency { get; set; }

        [Column("voltage")]
        public double? Voltage { get; set; }

        [Column("cas")]
        public int? Cas { get; set; }

        [Column("trcd")]
        public int? Trcd { get; set; }

        [Column("trp")]
        public int? Trp { get; set; }

        [Column("tras")]
        public int? Tras { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
