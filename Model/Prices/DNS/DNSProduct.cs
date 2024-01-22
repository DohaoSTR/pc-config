using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.DNS
{
    [Table("dns_product")]
    public class DNSProduct
    {
        [Key]
        [Column("uid")]
        public string UID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("part_number")]
        public string? PartNumber { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("category")]
        public string Category { get; set; }
    }
}
