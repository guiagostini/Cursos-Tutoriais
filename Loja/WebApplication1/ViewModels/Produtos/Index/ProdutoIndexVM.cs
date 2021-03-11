using System;

namespace WebApplication1.ViewModels.Produtos.Index
{
    public class ProdutoIndexVM
    {
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public short Quantidade { get; set; }

        public String Tipo { get; set; }
    }
}
