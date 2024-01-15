using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Case
{
    [Table("case_front_panel_usb")]
    public class CaseFrontPanelUSB
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
