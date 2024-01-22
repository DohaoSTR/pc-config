using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.PowerSupply
{
    [Table("power_supply_efficiency")]
    public class PowerSupplyEfficiency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("value")]
        public string Value { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
