using Store.Domain.Contracts.Repositories;
using Store.Domain.Enitities;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDataContextEF ctx) : base(ctx)
        {
        }

        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            return _ctx.Produtos.Where(p => p.Nome.Contains(contains));
        }
    }
}
