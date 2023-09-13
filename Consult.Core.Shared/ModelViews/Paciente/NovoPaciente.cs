using Consult.Core.Shared.ModelViews.Endereco;
using Consult.Core.Shared.ModelViews.Telefone;

namespace Consult.Core.Shared.ModelViews.Paciente;

/// <summary>
/// Objeto utilizado para inserção de um novo paciente.
/// </summary>
public class NovoPaciente
{
    /// <summary>
    /// Nome do paciente
    /// </summary>
    /// <example>João do Caminhão</example>
    public string Nome { get; set; }

    /// <summary>
    /// Data do nascimento do paciente.
    /// </summary>
    /// <example>1980-01-01</example>
    public DateTime DataNascimento { get; set; }

    /// <summary>
    /// Sexo do paciente
    /// </summary>
    /// <example>M</example>
    public SexoView Sexo { get; set; }

    /// <summary>
    /// Documento do paciente: CNH, CPF, RG
    /// </summary>
    /// <example>12341231312</example>
    public string Documento { get; set; }

    public NovoEndereco Endereco { get; set; }

    public ICollection<NovoTelefone> Telefones { get; set; }
}