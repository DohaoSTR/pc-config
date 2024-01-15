using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CaseFan
{
    [Table("case_fan_features")]
    public class CaseFanFeatures
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }

}
