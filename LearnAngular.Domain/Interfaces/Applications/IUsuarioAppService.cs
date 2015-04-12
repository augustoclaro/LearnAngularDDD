using LearnAngular.Domain.Entities;

namespace LearnAngular.Domain.Interfaces.Applications
{
    public interface IUsuarioAppService : IAppServiceBase, IAppDataServiceBase<Usuario>
    {
        void Registrar(Usuario usuario);
        Usuario Autenticar(string login, string senha);
    }
}
