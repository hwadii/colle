using Microsoft.AspNetCore.Mvc;

namespace Colle.Controllers;

[Route("[controller]")]
public class VersionController : Controller
{
    public ActionResult Get()
    {
        return View();
    }
}
