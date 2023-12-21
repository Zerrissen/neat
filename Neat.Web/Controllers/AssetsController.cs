using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Neat.Services;
using Neat.Web.RequestModels;
using Neat.Data.Models;

namespace Neat.Web.Controllers
{
    // * Define AssetsController class
    // * Controller for all endpoints related to assets
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {

        // * Declare instance and inject IAssetService for functionality related to assets
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }


        // * GET /api/assets
        // * Endpoint to return basic information on all (eventually paginated) assets
        [HttpGet]
        public IActionResult GetAssets()
        {
            var assets = _assetService.GetAllAssets();
            return Ok(assets);
        }

        // * GET /api/assets/{id}
        // * Endpoint to return detailed information on a single asset
        [HttpGet("{id}")]
        public IActionResult GetAssetById(int id)
        {
            var asset = _assetService.GetAssetDetail(id);
            if (asset == null)
            {
                return NoContent();
            }

            return Ok(asset);
        }

        // * POST /api/assets
        // * Endpoint to create a new asset
        [HttpPost]
        public IActionResult CreateAsset([FromBody] NewAssetRequest assetRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var now = DateTime.UtcNow.ToUniversalTime();
            var asset = new Asset
            {
                CreatedAt = now,
                UpdatedAt = now,
                Notes = assetRequest.Notes,
                Make = assetRequest.Make,
                Model = assetRequest.Model,
                Serial = assetRequest.Serial,
                PartNumber = assetRequest.PartNumber,
                Price = assetRequest.Price,
                PurchaseDate = assetRequest.PurchaseDate.ToUniversalTime(),
                WarrantyExpiration = assetRequest.WarrantyExpiration.ToUniversalTime(),
                CurrentConditionId = assetRequest.CurrentConditionId,
                LocationId = assetRequest.LocationId,
                AssetTypeId = assetRequest.AssetTypeId,
                StatusId = assetRequest.StatusId

            };

            _assetService.CreateAsset(asset);
            return Ok();
        }

        // * PUT /api/assets/{id}
        // * Endpoint to update an existing asset
        //TODO - Implement this
        [HttpPut("{id}")]
        public IActionResult UpdateAsset(int id)
        {
            return Ok();
        }

        // * DELETE /api/assets/{id}
        // * Endpoint to delete an existing asset
        //TODO - Implement this
        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            _assetService.DeleteAsset(id);
            return Ok();
        }
    }
}