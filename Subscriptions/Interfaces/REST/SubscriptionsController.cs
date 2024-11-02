using Microsoft.AspNetCore.Mvc;
using Security.Subscriptionss.Application.Internal.CommandServices;
using Security.Subscriptionss.Application.Internal.QueryServices;
using Security.Subscriptionss.Interfaces.REST.Resources;
using Security.Subscriptionss.Interfaces.REST.Transform;
using System.Net;

namespace Security.Subscriptionss.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsCommandService _SubscriptionsCommandService;
        private readonly ISubscriptionsQueryService _SubscriptionsQueryService;

        public SubscriptionsController(ISubscriptionsCommandService SubscriptionsCommandService, ISubscriptionsQueryService SubscriptionsQueryService)
        {
            _SubscriptionsCommandService = SubscriptionsCommandService;
            _SubscriptionsQueryService = SubscriptionsQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscriptions([FromBody] SubscriptionsResource SubscriptionsResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Subscriptions = SubscriptionsTransform.ToEntity(SubscriptionsResource);
                await _SubscriptionsCommandService.AddSubscriptionsAsync(Subscriptions);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptionss()
        {
            try
            {
                var Subscriptionss = await _SubscriptionsQueryService.GetAllSubscriptionssAsync();
                var SubscriptionsResources = Subscriptionss.Select(SubscriptionsTransform.ToResource);
                return Ok(SubscriptionsResources);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionsById(int id)
        {
            try
            {
                var Subscriptions = await _SubscriptionsQueryService.GetSubscriptionsByIdAsync(id);
                if (Subscriptions == null)
                {
                    return NotFound();
                }
                var SubscriptionsResource = SubscriptionsTransform.ToResource(Subscriptions);
                return Ok(SubscriptionsResource);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}