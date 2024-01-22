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
        public string? VoltageMode { get; set; }

        [Column("ampere")]
        public double? Ampere { get; set; }

        [Column("power")]
        public double? Power { get; set; }

        [Column("combined")]
        public string? Combined { get; set; }

        [Column("dc_mode")]
        public string? DCMode { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
