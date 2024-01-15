using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CPU
{
    [Table("cpu_main_data")]
    public class CPUMainData
    {
        [Key]
        public int Id { get; set; }

        [Column("tdp")]
        public int? TDP { get; set; }

        [Column("series")]
        public string? Series { get; set; }

        [Column("maximum_supported_memory")]
        public int? MaximumSupportedMemory { get; set; }

        [Column("ecc_support")]
        public string? ECCSupport { get; set; }

        [Column("includes_cooler")]
        public string? IncludesCooler { get; set; }

        [Column("packaging")]
        public string? Packaging { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
