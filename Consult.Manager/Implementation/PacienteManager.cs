using AutoMapper;
using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using Consult.Manager.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consult.Manager.Implementation
{
    public class PacienteManager : IPacienteManager
    {
        private readonly IPacienteRepository pacienteRepository;
        private readonly IMapper mapper;
        private readonly ILogger<PacienteManager> logger;

        public PacienteManager(IPacienteRepository pacienteRepository, IMapper mapper, ILogger<PacienteManager> logger)
        {
            this.pacienteRepository = pacienteRepository;
            this.mapper = mapper;
            this.logger = logger;
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

        public async Task<Paciente> InsertPacienteAsync(NovoPaciente novoPaciente)
        {
            logger.LogInformation("Chamada o 'negócio' para inserir um paciente.");
            var paciente = mapper.Map<Paciente>(novoPaciente);
            return await pacienteRepository.InsertPacienteAsync(paciente);
        }

        public async Task<Paciente> UpdatePacienteAsync(AlteraPaciente alteraPaciente)
        {
            var paciente = mapper.Map<Paciente>(alteraPaciente);
            return await pacienteRepository.UpdatePacienteAsync(paciente);
        }

    }
}
