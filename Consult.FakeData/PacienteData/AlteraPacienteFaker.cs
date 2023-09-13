using Consult.Core.Shared.ModelViews.Paciente;
using Consult.FakeData.EnderecoData;
using Consult.FakeData.TelefoneData;

namespace Consult.FakeData.PacienteData;

public class AlteraPacienteFaker : Faker<AlteraPaciente>
{
    public AlteraPacienteFaker()
    {
        var id = new Faker().Random.Number(1, 100);
        RuleFor(o => o.Id, _ => id);
        RuleFor(o => o.Nome, f => f.Person.FullName);
        RuleFor(o => o.Sexo, f => f.PickRandom<SexoView>());
        RuleFor(o => o.Telefones, _ => new NovoTelefoneFaker().Generate(3));
        RuleFor(o => o.Endereco, _ => new NovoEnderecoFaker().Generate());
    }
}