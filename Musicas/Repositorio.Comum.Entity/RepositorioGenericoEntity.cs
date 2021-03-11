using Repositorios.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Comum.Entity
{
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        protected DbContext _context;

        public RepositorioGenericoEntity(DbContext context)
        {
            _context = context;
        }
        public void Alterar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(TEntidade entidade)
        {
            _context.Set<TEntidade>().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            TEntidade entidade = SelecionarPorId(id);
            Excluir(entidade);
        }

        public void Inserir(TEntidade entidade)
        {
             _context.Set<TEntidade>().Add(entidade);
            _context.SaveChanges();

        }

        public virtual List<TEntidade> Selecionar()
        {
            return _context.Set<TEntidade>().ToList();
        }

        public virtual TEntidade SelecionarPorId(TChave id)
        {
            return _context.Set<TEntidade>().Find(id);
        }
    }
}
