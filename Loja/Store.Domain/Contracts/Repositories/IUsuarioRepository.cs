using Store.Domain.Enitities;

namespace Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario Get(string email);

    }
}
