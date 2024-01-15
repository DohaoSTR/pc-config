using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UsersData
{
    public enum UserType
    {
        [DatabaseValue("Standard")]
        Standard,
        [DatabaseValue("Google")]
        Google
    }

    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(250)]
        [Column("password")]
        public string? Password { get; set; }

        [Column("type")]
        public UserType Type { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
