using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Case
{
    [Table("case_drive_bay")]
    public class CaseDriveBay
    {
        [Key]
        public int Id { get; set; }

        public int? Count { get; set; }

        public string Type { get; set; }

        public double? Format { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
