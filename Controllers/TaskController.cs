using Task = API.Models.Task;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase {
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService, ILogger<TaskController> logger)
    {
        _logger = logger;
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult Get(){
        _logger.LogInformation("Retornando la lista de tareas");
        return Ok(_taskService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Task task){
        _logger.LogInformation("Agregando Tarea");
        return await _taskService.Save(task) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Task task){
        _logger.LogInformation("Actualizando Tarea");
        return await _taskService.Update(id, task) ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id){
        _logger.LogInformation("Eliminando Tarea");
        return await _taskService.Delete(id) ? Ok() : BadRequest();
    }
}