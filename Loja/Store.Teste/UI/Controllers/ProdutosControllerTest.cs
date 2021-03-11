using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;
using Store.Domain.Contracts.Repositories;
using Store.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.ViewModels.Produtos.Index;

namespace Store.Teste.UI.Controllers
{
    [TestClass, TestCategory("Controllers/ProdutosController")]
    public class ProdutosControllerTest
    {
        //dado um ProdutoController
        [TestMethod]
        public void MetodoIndexDeveraRetornarAViewComOModeloCorreto()
        {
            //arrange
            var produtoController = new ProdutosController(new ProdutoRepositoryFake(), new TipoProdutoRepositoryFake());

            //act
            var result = produtoController.Index();
            var model = result.Model as IEnumerable<ProdutoIndexVM>;

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.AreEqual(3, model.Count());
            Assert.IsNotNull(model);

        }

    }


    public class ProdutoRepositoryFake : IProdutoRepository
    {
        public void Add(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            var tipo1 = new TipoProduto() { Id = 1, Nome = "Tipo 1" };
            var tipo2 = new TipoProduto() { Id = 2, Nome = "Tipo 2" };

            return new List<Produto>
            {
                new Produto() {Id = 1, Nome = "Produto 1", Preco = 1, Quantidade = 10, TipoProdutoId = tipo1.Id, TipoProduto = tipo1 },
                new Produto() {Id = 2, Nome = "Produto 2", Preco = 2, Quantidade = 20, TipoProdutoId = tipo2.Id, TipoProduto = tipo2 },
                new Produto() {Id = 3, Nome = "Produto 3", Preco = 3, Quantidade = 30, TipoProdutoId = tipo1.Id, TipoProduto = tipo1 }
            };
        }

        public Produto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetByNameContains(string contains)
        {
            throw new NotImplementedException();
        }
    }

    public class TipoProdutoRepositoryFake : ITipoProdutoRepository
    {
        public void Add(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoProduto> Get()
        {
            throw new NotImplementedException();
        }

        public TipoProduto Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
