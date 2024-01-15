using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("fps_data")]
    public class FPSData
    {
        [Key]
        public int Id { get; set; }

        [Column("cpu_id")]
        public int? CpuId { get; set; }

        [ForeignKey("CpuId")]
        public Part? CPU { get; set; }

        [Column("gpu_id")]
        public int? GpuId { get; set; }

        [ForeignKey("GpuId")]
        public Part? GPU { get; set; }

        [Column("fps")]
        public double FPS { get; set; }

        [Column("samples")]
        public int Samples { get; set; }

        [Column("game_key")]
        public int GameKey { get; set; }

        [Column("resolution")]
        public Resolution Resolution { get; set; }

        [Column("game_settings")]
        public GameSettings GameSettings { get; set; }
    }
}
