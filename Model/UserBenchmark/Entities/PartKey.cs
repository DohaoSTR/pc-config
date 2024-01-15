using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("parts_keys")]
    public class PartKey
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("key")]
        public int Key { get; set; }
    }

}
