namespace Neat.Data.DTOs
{
    public class AssetSummaryDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string StatusName { get; set; }
        public string AssetTypeName { get; set; }
        public string LocationName { get; set; }
        public string ConditionName { get; set; }
    }
}