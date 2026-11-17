using Hollowmere.Server.DTOs;
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

        return models.Result == DbResult.Success ? Ok(models.Data) : NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = service.GetById(id);

        return result.Result == DbResult.Success ? Ok(result.Data) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatureCreateDTO creature)
    {
        var result = await service.Create(creature);

        return result.Result switch
        {
            DbResult.Success => CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data),
            DbResult.Exists => Conflict("Creature already exists."),
            DbResult.Concurrency => Conflict("Concurrency error."),
            DbResult.Error => BadRequest("An error occurred while creating the creature."),
            _ => BadRequest("An unexpected error occurred.")
        };
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreatureEditDTO creature)
    {
        if (id != creature.Id)
            return BadRequest("ID mismatch.");

        var result = await service.Update(creature);

        return result.Result switch
        {
            DbResult.Success => Ok(result.Data),
            DbResult.Exists => Conflict("Creature already exists."),
            DbResult.NotFound => NotFound("Creature not found."),
            DbResult.Concurrency => Conflict("Concurrency error."),
            DbResult.Error => BadRequest("An error occurred while updating the creature."),
            _ => BadRequest("An unexpected error occurred.")
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.Delete(id);

        return result.Result switch
        {
            DbResult.Success => NoContent(),
            DbResult.NotFound => NotFound("Creature not found."),
            DbResult.Concurrency => Conflict("Concurrency error."),
            DbResult.Error => BadRequest("An error occurred while deleting the creature."),
            _ => BadRequest("An unexpected error occurred.")
        };
    }
}
