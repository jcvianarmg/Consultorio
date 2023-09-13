using Consult.Core.Shared.ModelViews.Paciente;

namespace Consult.Manager.Mappings;

public class AlteraPacienteMappingProfile : Profile
{
    public AlteraPacienteMappingProfile()
    {
        CreateMap<AlteraPaciente, Paciente>()
           .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(_ => DateTime.Now))
           .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
    }
}