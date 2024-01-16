using Neat.Data.DTOs;
using Neat.Data.Models;

namespace Neat.Services
{
    public interface IPropertyService
    {
        public List<StatusOptionsDto> GetAllStatuses();
        public List<ConditionOptionsDto> GetAllConditions();
        public List<AssetTypeOptionsDto> GetAllAssetTypes();
        public List<LocationOptionsDto> GetAllLocations();
    }
}