﻿using Consult.Core.Shared.ModelViews.Usuario;

namespace Consult.Manager.Mappings;

public class UsuarioMappingProfile : Profile
{
    public UsuarioMappingProfile()
    {
        CreateMap<Usuario, UsuarioView>().ReverseMap();
        CreateMap<Usuario, NovoUsuario>().ReverseMap();
        CreateMap<Usuario, UsuarioLogado>().ReverseMap();
        CreateMap<Funcao, FuncaoView>().ReverseMap();
        CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
    }
}