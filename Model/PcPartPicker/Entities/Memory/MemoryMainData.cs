using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Memory
{
    [Table("memory_main_data")]
    public class MemoryMainData
    {
        [Key]
        public int Id { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("price_gb")]
        public double PricePerGB { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("register_memory")]
        public string RegisterMemory { get; set; }

        [Column("ecc")]
        public string ECC { get; set; }

        [Column("heat_spreader")]
        public string HeatSpreader { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
