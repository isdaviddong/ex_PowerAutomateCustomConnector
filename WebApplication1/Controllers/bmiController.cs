
using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BmiController : ControllerBase
{
    [HttpPost()]
    public ActionResult<double> CalculateBmi([FromBody] BmiRequest request)
    {
        if (request.HeightCm <= 0 || request.WeightKg <= 0)
        {
            return BadRequest("Height and weight must be greater than zero.");
        }

        double heightM = request.HeightCm / 100.0;
        double bmi = request.WeightKg / (heightM * heightM);
        return Ok(bmi);
    }
}

public class BmiRequest
{
    public double HeightCm { get; set; }
    public double WeightKg { get; set; }
}