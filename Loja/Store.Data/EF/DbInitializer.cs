using Store.Domain.Enitities;
using Store.Domain.Helpers;
using System.Collections.Generic;
using System.Data.Entity;

namespace Store.Data.EF
{
    internal class DbInitializer : CreateDatabaseIfNotExists<StoreDataContextEF>
    {
        protected override void Seed(StoreDataContextEF context)
        {
            var alimento = new TipoProduto() { Nome = "Alimento" };
            var higiene = new TipoProduto() { Nome = "Higiene" };
            var limpeza = new TipoProduto() { Nome = "Limpeza" };
            var eletronico = new TipoProduto() { Nome = "Eletronico" };

            var produtos = new List<Produto>() {
                new Produto() { Nome = "Picanha", Preco = 70.0M, Quantidade = 50, TipoProduto = alimento},
                new Produto() { Nome = "Pasta de Dente", Preco = 11.0M, Quantidade = 200, TipoProduto = higiene },
                new Produto() { Nome = "Shampoo", Preco = 31.0M, Quantidade = 150, TipoProduto = higiene },
                new Produto() { Nome = "Desifetante", Preco = 20.5M, Quantidade = 120, TipoProduto = limpeza },
                new Produto() { Nome = "Celular", Preco = 499.99M, Quantidade = 14, TipoProduto = eletronico }
            };

            context.Produtos.AddRange(produtos);

            context.Usuarios.Add(new Usuario()
            {
                Nome = "Guilherme",
                Email = "guilher.agostini@gmail.com",
                Senha = "123456".Encrypt()
            });

            context.SaveChanges();
        }
    }
}
