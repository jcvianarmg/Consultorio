using Consult.Core.Shared.ModelViews.Telefone;

namespace Consult.FakeData.TelefoneData;

public class NovoTelefoneFaker : Faker<NovoTelefone>
{
    public NovoTelefoneFaker()
    {
        RuleFor(p => p.Numero, f => f.Person.Phone);
    }
}