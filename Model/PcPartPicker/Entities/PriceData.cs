using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities
{
    [Table("price_data")]
    public class PriceData
    {
        [Key]
        public int Id { get; set; }

        [Column("merchant_link")]
        public string? MerchantLink { get; set; }

        [Column("merchant_name")]
        public string? MerchantName { get; set; }

        [Column("base_price")]
        public double? BasePrice { get; set; }

        [Column("promo_value")]
        public double? PromoValue { get; set; }

        [Column("shipping_text")]
        public string? ShippingText { get; set; }

        [Column("shipping_link")]
        public string? ShippingLink { get; set; }

        [Column("tax_value")]
        public double? TaxValue { get; set; }

        [Column("availability")]
        public string? Availability { get; set; }

        [Column("final_price")]
        public double? FinalPrice { get; set; }

        [Column("currency")]
        public char? Currency { get; set; }

        [Column("last_update_time")]
        public DateTime? LastUpdateTime { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
