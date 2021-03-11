using Store.Domain.Contracts.Repositories;
using Store.Domain.Enitities;
using System.Linq;

namespace Store.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(StoreDataContextEF ctx) : base(ctx)
        {

        }

        public Usuario Get(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
