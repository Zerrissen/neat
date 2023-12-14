using Neat.Data;
using Neat.Data.Models;
using Microsoft.EntityFrameworkCore;
using Neat.Data.DTOs;

namespace Neat.Services;

public class AssetService : IAssetService
{

    private readonly NeatDbContext _db;

    public AssetService(NeatDbContext db)
    {
        _db = db;
    }

    public List<AssetSummaryDto> GetAllAssets()
    {
        // TODO Use pagination to limit on a larger dataset
        //* Information returned is DTO, reduces amount of data sent
        return _db.Assets
            .Include(a => a.FKStatus)
            .Include(a => a.FKAssetType)
            .Include(a => a.FKLocation)
            .Include(a => a.FKCondition)
            .Select(a => new AssetSummaryDto
            {
                Id = a.Id,
                Make = a.Make,
                Model = a.Model,
                StatusName = a.FKStatus.Name,
                AssetTypeName = a.FKAssetType.Name,
                LocationName = a.FKLocation.Name,
                ConditionName = a.FKCondition.Name,
            })
            .ToList();
    }

    public AssetDetailDto GetAssetDetail(int assetId) // Marked as nullable, but we also handle null in the controller
    {

        return _db.Assets
            .Include(a => a.FKStatus)
            .Include(a => a.FKAssetType)
            .Include(a => a.FKLocation)
            .Include(a => a.FKCondition)
            .Where(a => a.Id == assetId)
            .Select(a => new AssetDetailDto
            {
                Id = a.Id,
                Notes = a.Notes,
                Make = a.Make,
                Model = a.Model,
                Serial = a.Serial,
                PartNumber = a.PartNumber,
                Price = a.Price,
                PurchaseDate = a.PurchaseDate,
                WarrantyExpiration = a.WarrantyExpiration,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                StatusName = a.FKStatus.Name,
                AssetTypeName = a.FKAssetType.Name,
                LocationName = a.FKLocation.Name,
                ConditionName = a.FKCondition.Name,
            })
            .SingleOrDefault();
    }

    public void CreateAsset(Asset asset)
    {
        _db.Add(asset);
        _db.SaveChanges();
    }

    public void DeleteAsset(int assetId)
    {
        var assetToDelete = _db.Assets.Find(assetId);
        // Because we aren't returning anything to the client, we throw exception here if asset isn't found
        if (assetToDelete == null)
        {
            throw new InvalidOperationException("Asset not found");
        }
        _db.Remove(assetToDelete);
        _db.SaveChanges();
    }


}
