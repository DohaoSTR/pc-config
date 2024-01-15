using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("games")]
    public class Game
    {
        [Key]
        public int Key { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

}
