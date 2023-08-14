using AutoMapper;
using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Consult.Manager.Mappings
{
    public class NovoPacienteMappingProfile : Profile
    {
        public NovoPacienteMappingProfile()
        {
            {
                CreateMap<NovoPaciente, Paciente>()
                    .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now))
                    .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
            }

        }
    }
}
