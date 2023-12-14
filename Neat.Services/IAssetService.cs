using Neat.Data.DTOs;
using Neat.Data.Models;

namespace Neat.Services
{
    public interface IAssetService
    {
        public List<AssetSummaryDto> GetAllAssets();
        public AssetDetailDto GetAssetDetail(int assetId);
        public void CreateAsset(Asset asset);
        public void DeleteAsset(int assetId);
    }
}