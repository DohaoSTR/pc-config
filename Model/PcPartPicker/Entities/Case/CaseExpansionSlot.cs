using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Case
{
    [Table("case_expansion_slot")]
    public class CaseExpansionSlot
    {
        [Key]
        public int Id { get; set; }

        public int? Count { get; set; }

        public string Type { get; set; }

        public string Riser { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }

}
