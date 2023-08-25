namespace Consult.Core.Domain
{
    public class Telefone
    {
        public int PacienteId { get; set; }
        public string Numero { get; set; }
        public Paciente Paciente { get; set; }
    }
}
