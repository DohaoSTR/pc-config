using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PCConfig.Model.PcPartPicker.Entities.PowerSupply
{
    [Table("power_supply")]
    public class PowerSupply
    {
        [Key]
        public int Id { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("efficiency_rating")]
        public string EfficiencyRating { get; set; }

        [Column("wattage")]
        public double Wattage { get; set; }

        [Column("length")]
        public double Length { get; set; }

        [Column("modular")]
        public string Modular { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("fan")]
        public string Fan { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
