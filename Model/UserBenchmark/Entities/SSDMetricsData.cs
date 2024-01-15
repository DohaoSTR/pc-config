using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("ssd_metrics_data")]
    public class SSDMetricsData
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("effective_speed")]
        public double? EffectiveSpeed { get; set; }

        [Column("avg_sequential_read_speed")]
        public double? AvgSequentialReadSpeed { get; set; }

        [Column("avg_sequential_write_speed")]
        public double? AvgSequentialWriteSpeed { get; set; }

        [Column("avg_4k_random_read_speed")]
        public double? Avg4KRandomReadSpeed { get; set; }

        [Column("avg_4k_random_write_speed")]
        public double? Avg4KRandomWriteSpeed { get; set; }

        [Column("avg_sequential_mixed_io_speed")]
        public double? AvgSequentialMixedIOSpeed { get; set; }

        [Column("avg_4k_random_mixed_io_speed")]
        public double? Avg4KRandomMixedIOSpeed { get; set; }

        [Column("avg_sustained_write_speed")]
        public double? AvgSustainedWriteSpeed { get; set; }

        [Column("peak_sequential_read_speed")]
        public double? PeakSequentialReadSpeed { get; set; }

        [Column("peak_sequential_write_speed")]
        public double? PeakSequentialWriteSpeed { get; set; }

        [Column("peak_4k_random_read_speed")]
        public double? Peak4KRandomReadSpeed { get; set; }

        [Column("peak_4k_random_write_speed")]
        public double? Peak4KRandomWriteSpeed { get; set; }

        [Column("peak_sequential_mixed_io_speed")]
        public double? PeakSequentialMixedIOSpeed { get; set; }

        [Column("peak_4k_random_mixed_io_speed")]
        public double? Peak4KRandomMixedIOSpeed { get; set; }

        [Column("peak_sequential_sustained_write_60s_average")]
        public double? PeakSequentialSustainedWrite60sAverage { get; set; }

        [Column("peak_4k_64_thread_read_speed")]
        public double? Peak4K64ThreadReadSpeed { get; set; }

        [Column("peak_4k_64_thread_write_speed")]
        public double? Peak4K64ThreadWriteSpeed { get; set; }

        [Column("peak_4k_64_thread_mixed_io_speed")]
        public double? Peak4K64ThreadMixedIOSpeed { get; set; }

        [Column("avg_4k_64_thread_read_speed")]
        public double? Avg4K64ThreadReadSpeed { get; set; }

        [Column("avg_4k_64_thread_write_speed")]
        public double? Avg4K64ThreadWriteSpeed { get; set; }

        [Column("avg_4k_64_thread_mixed_io_speed")]
        public double? Avg4K64ThreadMixedIOSpeed { get; set; }
    }
}
