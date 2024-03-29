using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase {

    [HttpGet]
    public IActionResult Get() => new JsonResult(from c in User.Claims select new { c.Type, c.Value });
}