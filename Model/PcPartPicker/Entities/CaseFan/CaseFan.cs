using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CaseFan
{
    [Table("case_fan")]
    public class CaseFan
    {
        [Key]
        public int Id { get; set; }

        public string Model { get; set; }

        public double Size { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public string PWM { get; set; }

        public string LED { get; set; }

        public string Controller { get; set; }

        [Column("static_pressure")]
        public double StaticPressure { get; set; }

        [Column("bearing_type")]
        public string BearingType { get; set; }

        [Column("min_rpm")]
        public double MinRpm { get; set; }

        [Column("max_rpm")]
        public double MaxRpm { get; set; }

        [Column("min_airflow")]
        public double MinAirflow { get; set; }

        [Column("max_airflow")]
        public double MaxAirflow { get; set; }

        [Column("min_noise_level")]
        public double MinNoiseLevel { get; set; }

        [Column("max_noise_level")]
        public double MaxNoiseLevel { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
