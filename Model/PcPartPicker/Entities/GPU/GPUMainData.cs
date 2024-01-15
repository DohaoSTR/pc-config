using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.GPU
{
    [Table("gpu_main_data")]
    public class GPUMainData
    {
        [Key]
        public int Id { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("chipset")]
        public string Chipset { get; set; }

        [Column("memory")]
        public double Memory { get; set; }

        [Column("memory_type")]
        public string MemoryType { get; set; }

        [Column("core_clock")]
        public int CoreClock { get; set; }

        [Column("boost_clock")]
        public int BoostClock { get; set; }

        [Column("effective_memory_clock")]
        public int EffectiveMemoryClock { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("frame_sync")]
        public string FrameSync { get; set; }

        [Column("tdp")]
        public int TDP { get; set; }

        [Column("radiator_mm")]
        public int RadiatorMM { get; set; }

        [Column("fans_count")]
        public int FansCount { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
