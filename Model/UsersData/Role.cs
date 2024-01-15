using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UsersData
{
    [Table("role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("name")]
        public string Name { get; set; }
    }
}
