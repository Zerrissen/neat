namespace Neat.Data.DTOs
{
    public class AssetDetailDto
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string PartNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string StatusName { get; set; }
        public string AssetTypeName { get; set; }
        public string LocationName { get; set; }
        public string ConditionName { get; set; }
    }
}