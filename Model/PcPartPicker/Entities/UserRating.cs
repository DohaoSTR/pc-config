using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities
{
    [Table("user_rating")]
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [Column("ratings_count")]
        public int? RatingsCount { get; set; }

        [Column("average_rating")]
        public double? AverageRating { get; set; }

        [Column("five_star")]
        public int? FiveStar { get; set; }

        [Column("four_star")]
        public int? FourStar { get; set; }

        [Column("three_star")]
        public int? ThreeStar { get; set; }

        [Column("two_star")]
        public int? TwoStar { get; set; }

        [Column("one_star")]
        public int? OneStar { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
