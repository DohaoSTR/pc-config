using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.DNS
{
    [Table("dns_price")]
    public class DNSPrice
    {
        [Key]
        public int Id { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("date_time")]
        public DateTime? DateTime { get; set; }

        [Column("product_id")]
        public string ProductId { get; set; }
    }
}
