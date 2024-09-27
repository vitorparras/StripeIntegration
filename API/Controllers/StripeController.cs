using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StripeController(IStripeService stripeService) : ControllerBase
    {
        private readonly IStripeService stripeService = stripeService ?? throw new ArgumentNullException(nameof(stripeService));

        [HttpPost("Create")]
        [SwaggerOperation(summary: "Criaçao")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = await stripeService.Create();
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Status")]
        [SwaggerOperation(summary: "Status")]
        public async Task<ActionResult> Status([FromQuery] string sessionId)
        {
            try
            {
                var response = await stripeService.GetStatus(sessionId);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
