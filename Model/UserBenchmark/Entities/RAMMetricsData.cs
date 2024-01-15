using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("ram_metrics_data")]
    public class RAMMetricsData
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("effective_speed")]
        public double? EffectiveSpeed { get; set; }

        [Column("avg_16_core_read_bench")]
        public double? Avg16CoreReadBench { get; set; }

        [Column("avg_16_core_write_bench")]
        public double? Avg16CoreWriteBench { get; set; }

        [Column("avg_16_core_mixed_io_bench")]
        public double? Avg16CoreMixedIOBench { get; set; }

        [Column("sixteen_core_read_bench")]
        public double? SixteenCoreReadBench { get; set; }

        [Column("sixteen_core_write_bench")]
        public double? SixteenCoreWriteBench { get; set; }

        [Column("sixteen_core_mixed_io_bench")]
        public double? SixteenCoreMixedIOBench { get; set; }

        [Column("avg_1_core_read_bench")]
        public double? Avg1CoreReadBench { get; set; }

        [Column("avg_1_core_write_bench")]
        public double? Avg1CoreWriteBench { get; set; }

        [Column("avg_1_core_mixed_io_bench")]
        public double? Avg1CoreMixedIOBench { get; set; }

        [Column("single_core_read_bench")]
        public double? SingleCoreReadBench { get; set; }

        [Column("single_core_write_bench")]
        public double? SingleCoreWriteBench { get; set; }

        [Column("single_core_mixed_io_bench")]
        public double? SingleCoreMixedIOBench { get; set; }
    }
}
