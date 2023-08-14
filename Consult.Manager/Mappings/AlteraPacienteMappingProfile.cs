using Consult.Core.Domain;
using Consult.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Consult.Manager.Mappings
{
    public class AlteraPacienteMappingProfile : Profile
    {
        public AlteraPacienteMappingProfile()
        {
            CreateMap<AlteraPaciente, Paciente>()
              .ForMember(d => d.DataAtualização, o => o.MapFrom(x => DateTime.Now))
              .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
