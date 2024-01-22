using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.DNS
{
    [Table("dns_available")]
    public class DNSAvailable
    {
        [Key]
        public int Id { get; set; }

        [Column("delivery_info")]
        public string? DeliveryInfo { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("date_time")]
        public DateTime? DateTime { get; set; }

        [Column("city_name")]
        public string CityName { get; set; }

        [Column("product_id")]
        public string ProductId { get; set; }
    }
}
