using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities
{
    [Table("part_number")]
    public class PartNumber
    {
        [Key]
        public int Id { get; set; }

        [Column("part_number")]
        public string Value { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
