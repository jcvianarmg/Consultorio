using Consult.Core.Shared.ModelViews.Especialidade;
using Consult.Core.Shared.ModelViews.Medico;

namespace Consult.Manager.Mappings;

public class NovoMedicoMappingProfile : Profile
{
    public NovoMedicoMappingProfile()
    {
        CreateMap<NovoMedico, Medico>();
        CreateMap<Medico, MedicoView>();
        CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
        CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
        CreateMap<Especialidade, NovaEspecialidade>().ReverseMap();
        CreateMap<AlteraMedico, Medico>().ReverseMap();
    }
}