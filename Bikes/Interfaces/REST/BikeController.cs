using Microsoft.AspNetCore.Mvc;
using Security.Bikes.Application.Internal.CommandServices;
using Security.Bikes.Application.Internal.QueryServices;
using Security.Bikes.Interfaces.REST.Resources;
using Security.Bikes.Interfaces.REST.Transform;
using System.Net;

namespace Security.Bikes.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeCommandService _bikeCommandService;
        private readonly IBikeQueryService _bikeQueryService;

        public BikeController(IBikeCommandService bikeCommandService, IBikeQueryService bikeQueryService)
        {
            _bikeCommandService = bikeCommandService;
            _bikeQueryService = bikeQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBike([FromBody] BikeResource bikeResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bike = BikeTransform.ToEntity(bikeResource);
                await _bikeCommandService.AddBikeAsync(bike);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            try
            {
                var bikes = await _bikeQueryService.GetAllBikesAsync();
                var bikeResources = bikes.Select(BikeTransform.ToResource);
                return Ok(bikeResources);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBikeById(int id)
        {
            try
            {
                var bike = await _bikeQueryService.GetBikeByIdAsync(id);
                if (bike == null)
                {
                    return NotFound();
                }
                var bikeResource = BikeTransform.ToResource(bike);
                return Ok(bikeResource);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}