using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.GPU
{
    [Table("gpu_external_power_data")]
    public class GPUExternalPowerData
    {
        [Key]
        public int Id { get; set; }

        [Column("interface_name")]
        public string? InterfaceName { get; set; }

        [Column("interface_count")]
        public int? InterfaceCount { get; set; }

        [Column("pin_count")]
        public int? PinCount { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
