using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaLivro
{
    public class Livro
{
        public Livro(int codigo, string titulo, double preco)
        {
            Titulo = titulo;
            Codigo = codigo;
            Preco = preco;
        }

    public string Titulo { get; set; }
    public int Codigo { get; set; }
    public double Preco { get; set; }

    }
}
