using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.Citilink
{
    [Table("citilink_available")]
    public class CitilinkAvailable
    {
        [Key]
        public int Id { get; set; }

        [Column("is_available")]
        public bool? IsAvailable { get; set; }

        [Column("date_time")]
        public DateTime? DateTime { get; set; }

        [Column("city_name")]
        public string CityName { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
    }
}
