using EmployeeAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController (IGetEmployeeUseCase getEmployeeUseCase) : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get(string name)
        {
            string result = "";

            try
            {
                result = getEmployeeUseCase.GetEmployee(name).Result;
                if (string.IsNullOrEmpty(result))
                {
                    return NotFound("User not found.");
                }

                return Ok("Hello, " + result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
