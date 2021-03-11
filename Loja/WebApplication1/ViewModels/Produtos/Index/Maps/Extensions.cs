using Store.Domain.Enitities;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.ViewModels.Produtos.Index.Maps
{
    public static class Extensions
    {
        public static IEnumerable<ProdutoIndexVM> ToProdutoIndexVM(this IEnumerable<Produto> data)
        {
            return data.Select(p => new ProdutoIndexVM()
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Tipo = p.TipoProduto.Nome,
                Quantidade = p.Quantidade,
                DataCadastro = p.DataCadastro
            });
        }
    }
}
