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
    }
}
