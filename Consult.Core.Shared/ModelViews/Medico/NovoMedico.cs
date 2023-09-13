using Consult.Core.Shared.ModelViews.Especialidade;

namespace Consult.Core.Shared.ModelViews.Medico;

public class NovoMedico
{
    public string Nome { get; set; }
    public int CRM { get; set; }
    public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
}