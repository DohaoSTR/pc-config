using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.GPU
{
    [Table("gpu_connect_data")]
    public class GPUConnectData
    {
        [Key]
        public int Id { get; set; }

        [Column("interface")]
        public string Interface { get; set; }

        [Column("length")]
        public int Length { get; set; }

        [Column("case_expansion_slot_width")]
        public int CaseExpansionSlotWidth { get; set; }

        [Column("total_slot_width")]
        public int TotalSlotWidth { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
