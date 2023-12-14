using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neat.Data.Models
{
    [Table("tbl_asset_records")]
    public class AssetRecord
    {
        [Key]
        [Column("asset_record_id")]
        public int Id { get; set; }

        [Column("issue_date")]
        public DateTime IssueDate { get; set; }

        [Column("return_date")]
        public DateTime ReturnDate { get; set; }

        [Column("issue_condition_id")]
        [ForeignKey("FKIssueCondition")]
        public int IssueConditionId { get; set; }
        public virtual Condition FKIssueCondition { get; set; }

        [Column("return_condition_id")]
        [ForeignKey("FKReturnCondition")]
        public int ReturnConditionId { get; set; }
        public virtual Condition FKReturnCondition { get; set; }

        [Column("asset_id")]
        [ForeignKey("FKAssetId")]
        public int AssetId { get; set; }
        public virtual Asset FKAsset { get; set; }
    }
}