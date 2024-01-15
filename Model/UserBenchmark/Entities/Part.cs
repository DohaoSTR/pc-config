using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("parts")]
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("part_number")]
        public string? PartNumber { get; set; }

        [Column("brand")]
        public string? Brand { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("rank")]
        public int Rank { get; set; }

        [Column("benchmark")]
        public double Benchmark { get; set; }

        [Column("samples")]
        public int Samples { get; set; }

        [Column("url")]
        public string Url { get; set; }
    }
}
