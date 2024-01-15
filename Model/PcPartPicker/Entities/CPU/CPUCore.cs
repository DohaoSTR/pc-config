using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CPU
{
    [Table("cpu_core")]
    public class CPUCore
    {
        [Key]
        public int Id { get; set; }

        [Column("core_count")]
        public int? CoreCount { get; set; }

        [Column("performance_core_clock")]
        public double? PerformanceCoreClock { get; set; }

        [Column("performance_boost_clock")]
        public double? PerformanceBoostClock { get; set; }

        [Column("microarchitecture")]
        public string? Microarchitecture { get; set; }

        [Column("core_family")]
        public string? CoreFamily { get; set; }

        [Column("socket")]
        public string? Socket { get; set; }

        [Column("lithography")]
        public int? Lithography { get; set; }

        [Column("integrated_graphics")]
        public string IntegratedGraphics { get; set; }

        [Column("simultaneous_multithreading")]
        public string? SimultaneousMultithreading { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
