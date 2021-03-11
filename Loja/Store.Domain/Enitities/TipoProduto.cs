using System.Collections.Generic;

namespace Store.Domain.Enitities
{
    public class TipoProduto : Entity
    {
        public string Nome { get; set; }
        public virtual ICollection<Produto> Podutos { get; set; }

    }
}
