using Bogus.Extensions.Brazil;
using Consult.Core.Shared.ModelViews.Paciente;
using Consult.FakeData.EnderecoData;
using Consult.FakeData.TelefoneData;

namespace Consult.FakeData.PacienteData;

public class NovoPacienteFaker : Faker<NovoPaciente>
{
    public NovoPacienteFaker()
    {
        RuleFor(p => p.Nome, f => f.Person.FullName);
        RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(p => p.Documento, f => f.Person.Cpf());
        RuleFor(p => p.DataNascimento, f => f.Date.Past());
        RuleFor(p => p.Telefones, _ => new NovoTelefoneFaker().Generate(3));
        RuleFor(p => p.Endereco, _ => new NovoEnderecoFaker().Generate());
    }
}