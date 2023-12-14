using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
    [Table("tbl_statuses")]
    public class Status
    {
        [Key]
        [Column("status_id")]
        public int Id { get; set; }

        [Column("status_name")]
        public string Name { get; set; }
    }
}