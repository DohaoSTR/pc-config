using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CPU
{
    [Table("cpu_cache")]
    public class CPUCache
    {
        [Key]
        public int Id { get; set; }

        [Column("count_lines_l1_instruction")]
        public int? CountLinesL1Instruction { get; set; }

        [Column("capacity_l1_instruction")]
        public int? CapacityL1Instruction { get; set; }

        [Column("capacity_measure_l1_instruction")]
        public string? CapacityMeasureL1Instruction { get; set; }

        [Column("count_lines_l1_data")]
        public int? CountLinesL1Data { get; set; }

        [Column("capacity_l1_data")]
        public int? CapacityL1Data { get; set; }

        [Column("capacity_measure_l1_data")]
        public string? CapacityMeasureL1Data { get; set; }

        [Column("count_lines_l2")]
        public int? CountLinesL2 { get; set; }

        [Column("capacity_l2")]
        public int? CapacityL2 { get; set; }

        [Column("capacity_measure_l2")]
        public string? CapacityMeasureL2 { get; set; }

        [Column("count_lines_l3")]
        public int? CountLinesL3 { get; set; }

        [Column("capacity_l3")]
        public int? CapacityL3 { get; set; }

        [Column("capacity_measure_l3")]
        public string? CapacityMeasureL3 { get; set; }

        [Required]
        [Column("type")]
        public string Type { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
