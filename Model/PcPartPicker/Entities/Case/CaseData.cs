using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Case
{
    [Table("case_data")]
    public class CaseData
    {
        [Key]
        public int Id { get; set; }

        [Column("power_supply")]
        public double? PowerSupply { get; set; }

        [Column("maximum_video_card_length_with")]
        public double? MaximumVideoCardLengthWith { get; set; }

        [Column("maximum_video_card_length_without")]
        public double? MaximumVideoCardLengthWithout { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        [Column("side_panel")]
        public string SidePanel { get; set; }

        [Column("has_power_supply")]
        public string HasPowerSupply { get; set; }

        [Column("power_supply_shroud")]
        public string PowerSupplyShroud { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public string Model { get; set; }

        public double? Volume { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }

}
