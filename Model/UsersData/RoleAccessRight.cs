using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UsersData
{
    [Table("role_access_right")]
    public class RoleAccessRight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }

}
