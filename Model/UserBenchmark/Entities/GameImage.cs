using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("game_images")]
    public class GameImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("image_data")]
        public byte[] ImageData { get; set; }

        [Required]
        [StringLength(250)]
        [Column("image_link")]
        public string ImageLink { get; set; }

        [Required]
        [Column("game_key")]
        public int GameKey { get; set; }

        [ForeignKey("GameKey")]
        public Game Game { get; set; }
    }
}
