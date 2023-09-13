namespace Consult.Manager.Interfaces.Services;

public interface IJwtService
{
    string GerarToken(Usuario usuario);
}