using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.InternalDrive
{
    [Table("hdd")]
    public class HDD
    {
        [Key]
        public int Id { get; set; }

        [Column("capacity")]
        public double? Capacity { get; set; }

        [Column("capacity_measure")]
        public string? CapacityMeasure { get; set; }

        [Column("price")]
        public double? Price { get; set; }

        [Column("price_measure")]
        public string? PriceMeasure { get; set; }

        [Column("cache")]
        public double? Cache { get; set; }

        [Column("cache_measure")]
        public string? CacheMeasure { get; set; }

        [Column("form_factor")]
        public string? FormFactor { get; set; }

        [Column("interface")]
        public string? Interface { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("power_loss_protection")]
        public string? PowerLossProtection { get; set; }

        [Column("spindle_speed")]
        public double? SpindleSpeed { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
