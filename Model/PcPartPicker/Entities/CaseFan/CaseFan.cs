using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CaseFan
{
    [Table("case_fan")]
    public class CaseFan
    {
        [Key]
        public int Id { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("size")]
        public double? Size { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("quantity")]
        public int? Quantity { get; set; }

        [Column("pwm")]
        public string? PWM { get; set; }

        [Column("led")]
        public string? LED { get; set; }

        [Column("controller")]
        public string? Controller { get; set; }

        [Column("static_pressure")]
        public double? StaticPressure { get; set; }

        [Column("bearing_type")]
        public string? BearingType { get; set; }

        [Column("min_rpm")]
        public double? MinRpm { get; set; }

        [Column("max_rpm")]
        public double? MaxRpm { get; set; }

        [Column("min_airflow")]
        public double? MinAirflow { get; set; }

        [Column("max_airflow")]
        public double? MaxAirflow { get; set; }

        [Column("min_noise_level")]
        public double? MinNoiseLevel { get; set; }

        [Column("max_noise_level")]
        public double? MaxNoiseLevel { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
