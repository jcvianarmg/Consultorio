using Consult.Core.Domain;
using Consult.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consult.Manager.Implementation
{
    public class PacienteManager : IPacienteManager
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteManager(IPacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            return await pacienteRepository.GetPacientesAsync();
        }

        public async Task<Paciente> GetPacienteAsync(int id)
        {
            return await pacienteRepository.GetPacienteAsync(id);
        }

        public async Task DeletePacienteAsync(int id)
        {
             await pacienteRepository.DeletePacienteAsync(id);
        }

        public async Task<Paciente> InsertPacienteAsync(Paciente paciente)
        {
            return await pacienteRepository.InsertPacienteAsync(paciente);
        }

        public async Task<Paciente> UpdatePacienteAsync(Paciente paciente)
        {
            return await pacienteRepository.UpdatePacienteAsync(paciente);
        }
    }
}
