using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Neat.Services;
using Neat.Web.RequestModels;
using Neat.Data.Models;

namespace Neat.Web.Controllers
{
    // * Define LocationsController class
    // * Controller for all endpoints related to statuses
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {

        // * Declare instance and inject IPropertyService for functionality related to properties
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // * GET /api/properties/statuses
        // * Endpoint to return names of all statuses
        [HttpGet("statuses")]
        public IActionResult GetStatuses()
        {
            var statuses = _propertyService.GetAllStatuses();
            if (statuses == null)
            {
                return NoContent();
            }

            return Ok(statuses);
        }

        // * GET /api/properties/conditions
        // * Endpoint to return names of all conditions
        [HttpGet("conditions")]
        public IActionResult GetConditions()
        {
            var conditions = _propertyService.GetAllConditions();
            if (conditions == null)
            {
                return NoContent();
            }

            return Ok(conditions);
        }

        // * GET /api/properties/asset-types
        // * Endpoint to return names of all asset types
        [HttpGet("asset-types")]
        public IActionResult GetAssetTypes()
        {
            var assetTypes = _propertyService.GetAllAssetTypes();
            if (assetTypes == null)
            {
                return NoContent();
            }

            return Ok(assetTypes);
        }

        // * GET /api/properties/locations
        // * Endpoint to return names of all locations
        [HttpGet("locations")]
        public IActionResult GetLocations()
        {
            var locations = _propertyService.GetAllLocations();
            if (locations == null)
            {
                return NoContent();
            }

            return Ok(locations);
        }
    }
}