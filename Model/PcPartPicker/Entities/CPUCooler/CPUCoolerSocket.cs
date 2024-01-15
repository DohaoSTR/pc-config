using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.CPUCooler
{
    [Table("cpu_cooler_socket")]
    public class CPUCoolerSocket
    {
        [Key]
        public int Id { get; set; }

        [Column("socket")]
        public string Socket { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
