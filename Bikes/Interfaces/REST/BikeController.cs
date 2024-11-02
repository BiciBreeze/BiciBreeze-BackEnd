using Microsoft.AspNetCore.Mvc;
using Security.Bikes.Application.Internal.CommandServices;
using Security.Bikes.Application.Internal.QueryServices;
using Security.Bikes.Interfaces.REST.Resources;
using Security.Bikes.Interfaces.REST.Transform;

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
            var bike = BikeTransform.ToEntity(bikeResource);
            await _bikeCommandService.AddBikeAsync(bike);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<BikeResource>> GetAllBikes()
        {
            var bikes = await _bikeQueryService.GetAllBikesAsync();
            return bikes.Select(BikeTransform.ToResource);
        }

        [HttpGet("{id}")]
        public async Task<BikeResource> GetBikeById(int id)
        {
            var bike = await _bikeQueryService.GetBikeByIdAsync(id);
            return BikeTransform.ToResource(bike);
        }
    }
}