using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.Motherboard
{
    [Table("motherboard_socket")]
    public class MotherboardSocket
    {
        [Key]
        public int Id { get; set; }

        [Column("socket_count")]
        public int SocketCount { get; set; }

        [Column("socket_name")]
        public string SocketName { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
