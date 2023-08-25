using System;
using System.Collections.Generic;

namespace Consult.Core.Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Endereco Endereco { get; set; }

    }
}
