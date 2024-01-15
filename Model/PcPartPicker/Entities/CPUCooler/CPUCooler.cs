using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CPUCooler
{
    [Table("cpu_cooler")]
    public class CPUCooler
    {
        [Key]
        public int Id { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("height")]
        public double Height { get; set; }

        [Column("water_cooled")]
        public double WaterCooled { get; set; }

        [Column("fan")]
        public string Fan { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("bearing")]
        public string Bearing { get; set; }

        [Column("min_rpm")]
        public double MinRpm { get; set; }

        [Column("max_rpm")]
        public double MaxRpm { get; set; }

        [Column("min_noise_level")]
        public double MinNoiseLevel { get; set; }

        [Column("max_noise_level")]
        public double MaxNoiseLevel { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }

}
