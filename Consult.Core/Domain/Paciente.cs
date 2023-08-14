using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Core.Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set;}
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? DataAtualização { get; set; }

    }
}
