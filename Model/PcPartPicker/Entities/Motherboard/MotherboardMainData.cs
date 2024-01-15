using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_main_data")]
    public class MotherboardMainData
    {
        [Key]
        public int Id { get; set; }

        [Column("form_factor")]
        public string FormFactor { get; set; }

        [Column("chipset")]
        public string Chipset { get; set; }

        [Column("memory_max")]
        public int MemoryMax { get; set; }

        [Column("memory_type")]
        public string MemoryType { get; set; }

        [Column("memory_slots")]
        public int MemorySlots { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("supports_ecc")]
        public string SupportsECC { get; set; }

        [Column("raid_support")]
        public string RaidSupport { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("onboard_video")]
        public string OnboardVideo { get; set; }

        [Column("wifi_standard")]
        public string WifiStandard { get; set; }

        [Column("network_adapter_speed")]
        public double NetworkAdapterSpeed { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
