using Bogus.Extensions.Brazil;
using Consult.FakeData.EnderecoData;
using Consult.FakeData.TelefoneData;

namespace Consult.FakeData.PacienteData;

public class PacienteFaker : Faker<Paciente>
{
    public PacienteFaker()
    {
        var id = new Faker().Random.Number(1, 999999);
        RuleFor(o => o.Id, _ => id);
        RuleFor(o => o.Nome, f => f.Person.FullName);
        RuleFor(o => o.Sexo, f => f.PickRandom<Sexo>());
        RuleFor(o => o.Documento, f => f.Person.Cpf());
        RuleFor(o => o.Criacao, f => f.Date.Past());
        RuleFor(o => o.UltimaAtualizacao, f => f.Date.Past());
        RuleFor(o => o.Telefones, _ => new TelefoneFaker(id).Generate(3));
        RuleFor(o => o.Endereco, _ => new EnderecoFaker(id).Generate());
    }
}