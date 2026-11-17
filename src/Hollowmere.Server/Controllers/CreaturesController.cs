using Hollowmere.Data.Models;
using Hollowmere.Server.Services;

using Microsoft.AspNetCore.Mvc;

namespace Hollowmere.Server.Controllers;


[ApiController]
[Route("[controller]")]
public class CreaturesController(CreaturesService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var models = service.GetAll();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) =>
        service.GetById(id) is Creature model ? Ok(model) : NotFound();


}
