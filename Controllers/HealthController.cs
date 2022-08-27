using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colle.Models;

namespace Colle.Controllers;

public struct Health
{
    public DateTime timestamp { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet(Name = "GetHealth")]
    public OkObjectResult Health()
    {
        var health = new Health { timestamp = DateTime.Now };
        return new OkObjectResult(health);
    }
}
