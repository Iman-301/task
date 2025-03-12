using Application.Tasks.Commands;
using Application.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTaskById), new { id }, command);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _mediator.Send(new GetTaskByIdQuery(id));
        return task != null ? Ok(task) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID mismatch");

        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var success = await _mediator.Send(new DeleteTaskCommand(id));
        return success ? NoContent() : NotFound();
    }
}
