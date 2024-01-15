using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.Prices.Citilink
{
    [Table("citilink_price")]
    public class CitilinkPrice
    {
        [Key]
        public int Id { get; set; }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }

        [Column("date_time")]
        public DateTime DateTime { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
    }
}
