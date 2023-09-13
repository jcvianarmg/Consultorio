namespace Consult.FakeData.TelefoneData;

public class TelefoneFaker : Faker<Telefone>
{
    public TelefoneFaker(int clientId)
    {
        RuleFor(o => o.PacienteId, _ => clientId);
        RuleFor(o => o.Numero, f => f.Person.Phone);
    }
}