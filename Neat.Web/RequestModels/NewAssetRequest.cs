namespace Neat.Web.RequestModels
{
    public class NewAssetRequest
    {
        // Supress nullable warnings here, we handle null values in Neat.Web/Controllers/AssetController.cs
#pragma warning disable CS8618
        public string Notes { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string PartNumber { get; set; }
#pragma warning restore CS8618
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiration { get; set; }
        public int CurrentConditionId { get; set; }
        public int LocationId { get; set; }
        public int AssetTypeId { get; set; }
        public int StatusId { get; set; }
    }
}