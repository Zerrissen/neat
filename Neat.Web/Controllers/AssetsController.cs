using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Neat.Services;
using Neat.Web.RequestModels;
using Neat.Data.Models;

namespace Neat.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }


        [HttpGet]
        public IActionResult GetAssets()
        {
            var assets = _assetService.GetAllAssets();
            return Ok(assets);
        }

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

        [HttpPut("{id}")]
        public IActionResult UpdateAsset(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            _assetService.DeleteAsset(id);
            return Ok();
        }
    }
}