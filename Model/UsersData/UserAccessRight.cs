using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UsersData
{
    [Table("user_access_right")]
    public class UserAccessRight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
