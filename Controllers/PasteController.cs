using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Colle.Models;

namespace Colle.Controllers;

[Route("[controller]")]
[ApiController]
public class PasteController : ControllerBase
{
    public ActionResult<Paste> Get()
    {
        return new OkObjectResult(new Paste {});
    }
}
