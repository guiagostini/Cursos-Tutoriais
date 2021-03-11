using Store.Domain.Contracts.Repositories;
using Store.Domain.Enitities;

namespace Store.Data.EF.Repositories
{
    public class TipoProdutoRepositoryEF : RepositoryEF<TipoProduto>, ITipoProdutoRepository
    {
        public TipoProdutoRepositoryEF(StoreDataContextEF ctx) : base(ctx)
        {
        }
    }
}
