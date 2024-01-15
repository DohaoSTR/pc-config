using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.PowerSupply
{
    [Table("power_supply_connectors")]
    public class PowerSupplyConnectors
    {
        [Key]
        public int Id { get; set; }

        [Column("atx_4pin_connectors")]
        public int? ATX4PinConnectors { get; set; }

        [Column("eps_8pin_connectors")]
        public int? EPS8PinConnectors { get; set; }

        [Column("pcie_12_4pin_12vhpwr_connectors")]
        public int? PCIe124Pin12VHPWRConnectors { get; set; }

        [Column("pcie_12pin_connectors")]
        public int? PCIe12PinConnectors { get; set; }

        [Column("pcie_8pin_connectors")]
        public int? PCIe8PinConnectors { get; set; }

        [Column("pcie_6_2pin_connectors")]
        public int? PCIe62PinConnectors { get; set; }

        [Column("pcie_6pin_connectors")]
        public int? PCIe6PinConnectors { get; set; }

        [Column("sata_connectors")]
        public int? SATAConnectors { get; set; }

        [Column("molex_4pin_connectors")]
        public int? Molex4PinConnectors { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
