using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_multi_interface")]
    public class MotherboardMultiInterface
    {
        [Key]
        public int Id { get; set; }

        [Column("ways_count")]
        public int WaysCount { get; set; }

        [Column("name_technology")]
        public string NameTechnology { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
