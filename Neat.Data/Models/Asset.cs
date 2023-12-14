using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
        [Table("tbl_assets")]
        public class Asset
        {
                [Key]
                [Column("asset_id")]
                public int Id { get; set; }

                [Column("notes")]
                [StringLength(200)]
                // Supress nullable warnings here, we handle null values in Neat.Web/Controllers/AssetController.cs
#pragma warning disable CS8618
                public string Notes { get; set; }

                [Column("make")]
                [Required]
                [StringLength(20)]
                public string Make { get; set; }

                [Column("model")]
                [StringLength(30)]
                [Required]
                public string Model { get; set; }

                [Column("serial")]
                [StringLength(50)]
                public string Serial { get; set; }

                [Column("part_number")]
                [StringLength(50)]
                public string PartNumber { get; set; }

                [Column("price")]
                public decimal Price { get; set; }
#pragma warning restore CS8618

                [Column("purchase_date")]
                [DataType(DataType.Date)]
                public DateTime PurchaseDate { get; set; }

                [Column("warranty_expiration")]
                [DataType(DataType.Date)]
                public DateTime WarrantyExpiration { get; set; }

                [Column("created_at")]
                [Required]
                public DateTime CreatedAt { get; set; }

                [Column("updated_at")]
                [Required]
                public DateTime UpdatedAt { get; set; }


                [Column("current_condition_id")]
                [ForeignKey("FKCondition")]
                public int CurrentConditionId { get; set; }
                public virtual Condition FKCondition { get; set; }

                [Column("location_id")]
                [ForeignKey("FKLocation")]
                public int LocationId { get; set; }
                public virtual Location FKLocation { get; set; }

                [Column("asset_type_id")]
                [ForeignKey("FKAssetType")]
                public int AssetTypeId { get; set; }
                public virtual AssetType FKAssetType { get; set; }

                [Column("status_id")]
                [ForeignKey("FKStatus")]
                public int StatusId { get; set; }
                public virtual Status FKStatus { get; set; }
        }
}