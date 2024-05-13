public class MemoryRepository
{
    private List<Aluno> _alunos = new List<Aluno>();
    private List<Escola> _escolas = new List<Escola>();

    public List<Aluno> GetAlunos()
    {
        return _alunos;
    }

    public Aluno GetAluno(int id)
    {
        return _alunos.Find(a => a.iCodAluno == id);
    }

    public void CreateAluno(Aluno aluno)
    {
        _alunos.Add(aluno);
    }

    public void UpdateAluno(Aluno aluno)
    {
        var existingAluno = _alunos.Find(a => a.iCodAluno == aluno.iCodAluno);
        if (existingAluno != null)
        {
            existingAluno.sNome = aluno.sNome;
            existingAluno.dNascimento = aluno.dNascimento;
            existingAluno.sCPF = aluno.sCPF;
            existingAluno.sEndereco = aluno.sEndereco;
            existingAluno.sCelular = aluno.sCelular;
            existingAluno.iCodEscola = aluno.iCodEscola;
        }
    }

    public void DeleteAluno(int id)
    {
        _alunos.Remove(GetAluno(id));
    }

    public List<Escola> GetEscolas()
    {
        return _escolas;
    }

    public Escola GetEscola(int id)
    {
        return _escolas.Find(e => e.iCodEscola == id);
    }

    public void CreateEscola(Escola escola)
    {
        _escolas.Add(escola);
    }

    public void UpdateEscola(Escola escola)
    {
        var existingEscola = _escolas.Find(e => e.iCodEscola == escola.iCodEscola);
        if (existingEscola != null)
        {
            existingEscola.sDescricao = escola.sDescricao;
        }
    }

    public void DeleteEscola(int id)
    {
        _escolas.Remove(GetEscola(id));
    }
}