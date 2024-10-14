using Microsoft.AspNetCore.Mvc;
using Divide25.Services;
using Divide25.Models;

namespace Divide25.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmallestDivisibleController : ControllerBase
    {
        private readonly DivisibleService _divisibleService;

        //  Injecting the DivisibleService, which handles the business side of things for  finding the smallest divisible number
        public SmallestDivisibleController(DivisibleService divisibleService)
        {
            _divisibleService = divisibleService;
        }

        [HttpPost]
        public IActionResult GetSmallestDivisible([FromBody] RangeRequest request)
        {
            if (request.Start <= 0 || request.End <= 0)
            {
                return BadRequest(new { error = "Start and End values must be greater than zero" });
            }

            try
            {
                var result = _divisibleService.GetSmallestNumberDivisibleByRange(request.Start, request.End);
                return Ok(new { result });
            }
            catch (OverflowException)
            {
                return StatusCode(500, new { error = "Calculation resulted in an overflow. Please use smaller values." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred. Please try again later.", ex });
            }
        }
    }
}
