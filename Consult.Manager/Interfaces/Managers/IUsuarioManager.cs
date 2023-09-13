using Consult.Core.Shared.ModelViews.Usuario;

namespace Consult.Manager.Interfaces.Managers;

public interface IUsuarioManager
{
    Task<IEnumerable<UsuarioView>> GetAsync();

    Task<UsuarioView> GetAsync(string login);

    Task<UsuarioView> InsertAsync(NovoUsuario usuario);

    Task<UsuarioView> UpdateMedicoAsync(Usuario usuario);

    Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario);
}