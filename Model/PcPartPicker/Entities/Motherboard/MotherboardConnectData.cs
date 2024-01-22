using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_connect_data")]
    public class MotherboardConnectData
    {
        [Key]
        public int Id { get; set; }

        [Column("pcie_x16_slots")]
        public int? PcieX16Slots { get; set; }

        [Column("pcie_x8_slots")]
        public int? PcieX8Slots { get; set; }

        [Column("pcie_x4_slots")]
        public int? PcieX4Slots { get; set; }

        [Column("pcie_x1_slots")]
        public int? PcieX1Slots { get; set; }

        [Column("pci_slots")]
        public int? PciSlots { get; set; }

        [Column("mini_pcie_slots")]
        public int? MiniPcieSlots { get; set; }

        [Column("half_mini_pcie_slots")]
        public int? HalfMiniPcieSlots { get; set; }

        [Column("mini_pcie_msata_slots")]
        public int? MiniPcieMsataSlots { get; set; }

        [Column("msata_slots")]
        public int? MsataSlots { get; set; }

        [Column("sata_6_0")]
        public int? Sata6_0 { get; set; }

        [Column("pata_100")]
        public int? Pata100 { get; set; }

        [Column("sata_3_0")]
        public int? Sata3_0 { get; set; }

        [Column("esata_6_0")]
        public int? Esata6_0 { get; set; }

        [Column("u_2")]
        public int? U2 { get; set; }

        [Column("esata_3_0")]
        public int? Esata3_0 { get; set; }

        [Column("sas_3_0")]
        public int? Sas3_0 { get; set; }

        [Column("pata_133")]
        public int? Pata133 { get; set; }

        [Column("sas_12_0")]
        public int? Sas12_0 { get; set; }

        [Column("sas_6_0")]
        public int? Sas6_0 { get; set; }

        [Column("sata_1_5")]
        public int? Sata1_5 { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
