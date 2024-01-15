using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.Citilink
{
    [Table("citilink_product")]
    public class CitilinkProduct
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("part_number")]
        public string PartNumber { get; set; }

        [Column("category")]
        public string Category { get; set; }
    }
}
