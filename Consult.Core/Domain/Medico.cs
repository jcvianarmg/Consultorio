using System;
using System.Collections.Generic;
using System.Text;

namespace Consult.Core.Domain
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }

        public ICollection<Especialidade> Especialidades { get; set; }
    }
}
