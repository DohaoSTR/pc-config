using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model
{
    public abstract class DataBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public DataBaseEntity(int id)
        {
            Id = id;
        }

        public DataBaseEntity()
        { }
    }
}
