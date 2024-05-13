using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly MemoryRepository _repository;

    public AlunosController(MemoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAlunos()
    {
        return Ok(_repository.GetAlunos());
    }

    [HttpGet("{id}")]
    public IActionResult GetAluno(int id)
    {
        var aluno = _repository.GetAluno(id);
        if (aluno == null)
        {
            return NotFound();
        }
        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult CreateAluno(Aluno aluno)
    {
        _repository.CreateAluno(aluno);
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.iCodAluno }, aluno);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAluno(int id, Aluno aluno)
    {
        var existingAluno = _repository.GetAluno(id);
        if (existingAluno == null)
        {
            return NotFound();
        }
        _repository.UpdateAluno(aluno);
        return Ok(aluno);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAluno(int id)
    {
        _repository.DeleteAluno(id);
        return NoContent();
    }
}