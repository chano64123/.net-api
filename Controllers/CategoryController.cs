using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase {
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Get(){
        _logger.LogInformation("Retornando la lista de categorias");
        return Ok(_categoryService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Category category){
        _logger.LogInformation("Agregando Categoria");
        return await _categoryService.Save(category) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Category category){
        _logger.LogInformation("Actualizando Categoria");
        return await _categoryService.Update(id, category) ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id){
        _logger.LogInformation("Eliminando Categoria");
        return await _categoryService.Delete(id) ? Ok() : BadRequest();
    }
}