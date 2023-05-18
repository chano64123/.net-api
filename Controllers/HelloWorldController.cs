using API;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly TasksContext _context;
    private readonly IHelloWorldService helloWorldService;
    public HelloWorldController(IHelloWorldService helloWorld, TasksContext context, ILogger<WeatherForecastController> logger)
    {
        _context = context;
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]
    public IActionResult Get(){
        _logger.LogDebug("Retornando Hola Mundito");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("create-db")]
    public IActionResult CreateDatabase(){
        _logger.LogInformation("Revisando DB");
        bool dbInServer = _context.Database.EnsureCreated();
        return Ok($"DB in server => {dbInServer}");
    }
}