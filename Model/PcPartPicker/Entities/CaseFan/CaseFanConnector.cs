using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CaseFan
{
    [Table("case_fan_connector")]
    public class CaseFanConnector
    {
        [Key]
        public int Id { get; set; }

        [Column("pin_count")]
        public int PinCount { get; set; }

        [Column("volt_count")]
        public int VoltCount { get; set; }

        public string RGB { get; set; }

        public string Proprietary { get; set; }

        public string Addressable { get; set; }

        public string PWM { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }

}
