using Neat.Data;
using Neat.Data.Models;
using Microsoft.EntityFrameworkCore;
using Neat.Data.DTOs;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Neat.Services;

public class PropertyService : IPropertyService
{

    private readonly NeatDbContext _db;

    public PropertyService(NeatDbContext db)
    {
        _db = db;
    }

    // * GET /api/properties/statuses
    public List<StatusOptionsDto> GetAllStatuses()
    {
        //* Information returned is DTO, reduces amount of data sent
        return _db.Statuses
            .Select(s => new StatusOptionsDto
            {
                StatusName = s.Name,
            })
            .ToList();
    }

    // * GET /api/properties/conditions
    public List<ConditionOptionsDto> GetAllConditions()
    {
        //* Information returned is DTO, reduces amount of data sent
        return _db.Conditions
            .Select(c => new ConditionOptionsDto
            {
                ConditionName = c.Name,
            })
            .ToList();
    }

    // * GET /api/properties/asset-types
    public List<AssetTypeOptionsDto> GetAllAssetTypes()
    {
        //* Information returned is DTO, reduces amount of data sent
        return _db.AssetTypes
            .Select(at => new AssetTypeOptionsDto
            {
                AssetTypeName = at.Name,
            })
            .ToList();
    }

    // * GET /api/properties/locations
    public List<LocationOptionsDto> GetAllLocations()
    {
        //* Information returned is DTO, reduces amount of data sent
        return _db.Locations
            .Select(l => new LocationOptionsDto
            {
                LocationName = l.Name,
            })
            .ToList();
    }
}
