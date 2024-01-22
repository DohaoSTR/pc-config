using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Case
{
    [Table("case_motherboard_form_factor")]
    public class CaseMotherboardFormFactor
    {
        [Key]
        public int Id { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
