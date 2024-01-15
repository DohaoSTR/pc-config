using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_ethernet")]
    public class MotherboardEthernet
    {
        [Key]
        public int Id { get; set; }

        [Column("network_adapter_count")]
        public int NetworkAdapterCount { get; set; }

        [Column("network_adapter_speed")]
        public double NetworkAdapterSpeed { get; set; }

        [Column("speed_measure")]
        public string SpeedMeasure { get; set; }

        [Column("network_adapter")]
        public string NetworkAdapter { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
