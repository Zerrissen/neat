using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
    [Table("tbl_conditions")]
    public class Condition
    {
        [Key]
        [Column("condition_id")]
        public int Id { get; set; }

        [Column("condition_name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}