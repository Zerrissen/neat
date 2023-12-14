using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
    [Table("tbl_asset_types")]
    public class AssetType
    {
        [Key]
        [Column("asset_type_id")]
        public int Id { get; set; }

        [Column("type_name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}