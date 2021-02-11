using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaLivro
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivro()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro(01, "Harry Potter e a Pedra Filosofal", 89.9));
            livros.Add(new Livro(02, "1984", 99.9));
            livros.Add(new Livro(03, "Vidas Secas", 33.9));
            return livros;
        }

    }
}
