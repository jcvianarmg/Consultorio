using Bogus.Extensions.Brazil;
using Consult.Core.Shared.ModelViews.Paciente;
using Consult.FakeData.EnderecoData;
using Consult.FakeData.TelefoneData;

namespace Consult.FakeData.PacienteData;

public class PacienteViewFaker : Faker<PacienteView>
{
    public PacienteViewFaker()
    {
        var id = new Faker().Random.Number(1, 999999);
        _ = RuleFor(p => p.Id,
            _ => id);
        RuleFor(p => p.Nome, f => f.Person.FullName);
        RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(p => p.Documento, f => f.Person.Cpf());
        RuleFor(p => p.Criacao, f => f.Date.Past());
        RuleFor(p => p.UltimaAtualizacao, f => f.Date.Past());
        RuleFor(p => p.DataNascimento, f => f.Date.Past());
        RuleFor(p => p.Telefones, _ => new TelefoneViewFaker().Generate(3));
        RuleFor(p => p.Endereco, _ => new EnderecoViewFaker().Generate());
    }
}