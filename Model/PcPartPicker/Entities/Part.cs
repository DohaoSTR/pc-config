using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities
{
    [Table("part")]
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Column("manufacturer")]
        [Required]
        [StringLength(250)]
        public string Manufacturer { get; set; }

        [Column("name")]
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Column("link")]
        [Required]
        [StringLength(250)]
        public string Link { get; set; }

        [Column("part_type")]
        [Required]
        [StringLength(50)]
        public string PartType { get; set; }

        [Column("key")]
        [Required]
        [StringLength(50)]
        public string Key { get; set; }
    }
}
