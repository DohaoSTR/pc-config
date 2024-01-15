using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.PowerSupply
{
    [Table("power_supply_output")]
    public class PowerSupplyOutput
    {
        [Key]
        public int Id { get; set; }

        [Column("voltage_mode")]
        public string VoltageMode { get; set; }

        public double? Ampere { get; set; }

        public double? Power { get; set; }

        public string Combined { get; set; }

        [Column("dc_mode")]
        public string DCMode { get; set; }

        public string Description { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
