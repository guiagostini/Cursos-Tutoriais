using Store.Domain.Enitities;

namespace WebApplication1.ViewModels.Produtos.AddEdit.Maps
{
    public static class Extensions
    {
        public static ProdutoAddEditVM ToProdutoAddEditVM(this Produto model)
        {
            return new ProdutoAddEditVM()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Quantidade = model.Quantidade,
                DataCadastro = model.DataCadastro
            };
        }

        public static Produto ToProduto(this ProdutoAddEditVM model)
        {
            return new Produto()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Quantidade = model.Quantidade,
                DataCadastro = model.DataCadastro
            };
        }
    }
}
