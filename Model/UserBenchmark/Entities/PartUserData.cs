using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("part_user_data")]
    public class PartUserData
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("ubm_user_rating")]
        public int? UBMUserRating { get; set; }

        [Column("market_share")]
        public double? MarketShare { get; set; }

        [Column("price")]
        public double? Price { get; set; }

        [Column("vfm")]
        public double? VFM { get; set; }

        [Column("newest")]
        public int? Newest { get; set; }
    }

}
