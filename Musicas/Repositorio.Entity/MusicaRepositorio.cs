using Musicas.AcessoDados.Entity.Context;
using Musicas.Dominio;
using Repositorio.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Repositorio.Entity
{
    public class MusicaRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        public MusicaRepositorio(MusicasDbContext context)
            : base(context)
        {

        }

        public override List<Musica> Selecionar()
        {
            return _context.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionarPorId(long id)
        {
            return _context.Set<Musica>().Include(p => p.Album).SingleOrDefault(m => m.Id == id);
        }
    }
}
