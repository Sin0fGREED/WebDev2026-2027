using Hollowmere.Server.DTOs;
using Hollowmere.Server.Services;

using Microsoft.AspNetCore.Mvc;

namespace Hollowmere.Server.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestController(QuestService service) : ControllerBase
{
    [HttpGet]
        public IActionResult GetAll()
    {
        var models = service.GetAll();

        return models.Result == DbResult.Success ? Ok(models.Data) : NotFound();
    }

    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        var result = service.GetById(id);

        return result.Result == DbResult.Success ? Ok(result.Data) : NotFound();
    }

    

}