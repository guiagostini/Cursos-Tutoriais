using Musicas.AcessoDados.Entity.Context;
using Musicas.Dominio;
using Repositorio.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Musicas.Repositorio.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album,int>
    {
        public AlbumRepositorio(MusicasDbContext context)
            : base(context)
        {

        }

        public override List<Album> Selecionar()
        {
            return _context.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _context.Set<Album>().Include(p => p.Musicas).SingleOrDefault(m => m.Id == id);
        }
    }
}
