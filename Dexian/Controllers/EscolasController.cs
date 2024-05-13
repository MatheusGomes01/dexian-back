using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EscolasController : ControllerBase
{
    private readonly MemoryRepository _repository;

    public EscolasController(MemoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetEscolas()
    {
        return Ok(_repository.GetEscolas());
    }

    [HttpGet("{id}")]
    public IActionResult GetEscola(int id)
    {
        var escola = _repository.GetEscola(id);
        if (escola == null)
        {
            return NotFound();
        }
        return Ok(escola);
    }

    [HttpPost]
    public IActionResult CreateEscola(Escola escola)
    {
        _repository.CreateEscola(escola);
        return CreatedAtAction(nameof(GetEscola), new { id = escola.iCodEscola }, escola);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEscola(int id, Escola escola)
    {
        var existingEscola = _repository.GetEscola(id);
        if (existingEscola == null)
        {
            return NotFound();
        }
        _repository.UpdateEscola(escola);
        return Ok(escola);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEscola(int id)
    {
        _repository.DeleteEscola(id);
        return NoContent();
    }
}