using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_m2_slots")]
    public class MotherboardM2Slots
    {
        [Key]
        public int Id { get; set; }

        [Column("standard_size")]
        public int? StandardSize { get; set; }

        [Column("key_name")]
        public string? KeyName { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
