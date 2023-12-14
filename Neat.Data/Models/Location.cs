using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
    [Table("tbl_locations")]
    public class Location
    {
        [Key]
        [Column("location_id")]
        public int Id { get; set; }

        [Column("location_name")]
        public string Name { get; set; }
    }
}