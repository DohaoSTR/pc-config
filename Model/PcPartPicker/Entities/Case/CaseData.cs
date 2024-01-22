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

        [Column("type")]
        public string? Type { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("side_panel")]
        public string? SidePanel { get; set; }

        [Column("has_power_supply")]
        public string? HasPowerSupply { get; set; }

        [Column("power_supply_shroud")]
        public string? PowerSupplyShroud { get; set; }

        [Column("length")]
        public double? Length { get; set; }

        [Column("width")]
        public double? Width { get; set; }

        [Column("height")]
        public double? Height { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("volume")]
        public double? Volume { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }

}
