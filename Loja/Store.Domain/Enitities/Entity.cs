using System;

namespace Store.Domain.Enitities
{
    public class Entity
    {
        public Entity()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } 
    }
}
