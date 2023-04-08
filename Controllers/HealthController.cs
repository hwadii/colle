using Microsoft.AspNetCore.Mvc;

namespace Colle.Controllers;

public struct Health
{
    public DateTime timestamp { get; set; }
}

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<Health> Index()
    {
        return new OkObjectResult(new Health { timestamp = DateTime.Now });
    }
}
