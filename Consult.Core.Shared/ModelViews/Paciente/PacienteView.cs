using Consult.Core.Shared.ModelViews.Endereco;
using Consult.Core.Shared.ModelViews.Telefone;

namespace Consult.Core.Shared.ModelViews.Paciente;

public class PacienteView : ICloneable
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public SexoView Sexo { get; set; }
    public ICollection<TelefoneView> Telefones { get; set; }

    public string Documento { get; set; }
    public DateTime Criacao { get; set; }
    public DateTime? UltimaAtualizacao { get; set; }

    public EnderecoView Endereco { get; set; }

    public object Clone()
    {
        var paciente = (PacienteView)MemberwiseClone();
        paciente.Endereco = (EnderecoView)paciente.Endereco.Clone();
        var telefones = new List<TelefoneView>();
        paciente.Telefones.ToList().ForEach(p => telefones.Add((TelefoneView)p.Clone()));
        paciente.Telefones = telefones;
        return paciente;
    }

    public PacienteView CloneTipado()
    {
        return (PacienteView)Clone();
    }
}