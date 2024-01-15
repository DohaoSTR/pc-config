using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UsersData
{
    [Table("log")]
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("country_code")]
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("timezone")]
        public string TimeZone { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("ip_address")]
        public string IpAddress { get; set; }

        [Required]
        [Column("date_time")]
        public DateTime DateTime { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public DateOnly Date => DateOnly.FromDateTime(DateTime);

        public TimeOnly Time => TimeOnly.FromDateTime(DateTime);
    }
}
