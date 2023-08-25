using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Core.Shared.ModelViews
{

    /// <summary>
    /// Objeto utilizado para inserir um novo Paciente.
    /// </summary>
    /// 
    public class NovoPaciente
    {
        /// <summary>
        /// Novo paciente
        /// </summary>
        /// <example>Recrutrador Técnico</example> 
        public string Nome { get; set; }

        /// <summary>
        /// Data do nascimento do Paciente.
        /// </summary>
        /// <example>1990-01-01</example>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo do Paciente
        /// </summary>
        /// <example>M</example>
        public SexoView Sexo { get; set; }

        /// <summary>
        /// Documento do Paciente: RG, CPF,CNH 
        /// </summary>
        /// <example>12333331312</example>
        public string Documento { get; set; }

        public NovoEndereco Endereco { get; set; }

        public ICollection<NovoTelefone> Telefones { get; set; }

    }
}
