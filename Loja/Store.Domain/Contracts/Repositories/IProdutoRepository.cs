using Store.Domain.Enitities;
using System.Collections.Generic;

namespace Store.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetByNameContains(string contains);

    }
}
