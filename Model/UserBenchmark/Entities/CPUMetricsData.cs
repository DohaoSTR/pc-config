using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("cpu_metrics_data")]
    public class CPUMetricsData
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }

        [Column("effective_speed")]
        public double? EffectiveSpeed { get; set; }

        [Column("avg_memory_latency")]
        public double? AvgMemoryLatency { get; set; }

        [Column("avg_single_core_speed")]
        public double? AvgSingleCoreSpeed { get; set; }

        [Column("avg_dual_core_speed")]
        public double? AvgDualCoreSpeed { get; set; }

        [Column("avg_quad_core_speed")]
        public double? AvgQuadCoreSpeed { get; set; }

        [Column("avg_octa_core_speed")]
        public double? AvgOctaCoreSpeed { get; set; }

        [Column("avg_multi_core_speed")]
        public double? AvgMultiCoreSpeed { get; set; }

        [Column("oc_memory_core_speed")]
        public double? OcMemoryCoreSpeed { get; set; }

        [Column("oc_single_core_speed")]
        public double? OcSingleCoreSpeed { get; set; }

        [Column("oc_dual_core_speed")]
        public double? OcDualCoreSpeed { get; set; }

        [Column("oc_quad_core_speed")]
        public double? OcQuadCoreSpeed { get; set; }

        [Column("oc_octa_core_speed")]
        public double? OcOctaCoreSpeed { get; set; }

        [Column("oc_multi_core_speed")]
        public double? OcMultiCoreSpeed { get; set; }
    }
}
