using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("metrics")]
    public class Metrics
    {
        [Key]
        public int Id { get; set; }

        [Column("gaming_percentage")]
        public int GamingPercentage { get; set; }

        [Column("desktop_percentage")]
        public int DesktopPercentage { get; set; }

        [Column("workstation_percentage")]
        public int WorkstationPercentage { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }
    }
}
