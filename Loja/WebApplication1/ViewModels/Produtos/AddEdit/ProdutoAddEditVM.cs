using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Produtos.AddEdit
{
    public class ProdutoAddEditVM
    {
        public ProdutoAddEditVM()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public short Quantidade { get; set; }

        [Display(Name = "Tipo do Produto")]
        public int TipoProdutoId { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
