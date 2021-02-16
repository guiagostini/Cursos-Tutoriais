using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capitulo1.Data.DAL.Cadastro
{
    public class InstituicaoDAL
    {
        private IESContext _context;

        public InstituicaoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Instituicao> ObterInstituicoesClassificadasPorNome()
        {
            return _context.Instituicao.OrderBy(b => b.Nome);
        }

        public async Task<Instituicao> ObterInstituicaoPorID(long id)
        {
            return await _context.Instituicao.Include(d => d.Departamentos).SingleOrDefaultAsync(m => m.InstituicaoID == id);
        }

        public async Task<Instituicao> GravarInstituicao(Instituicao instituicao)
        {
            if (instituicao.InstituicaoID == null)
            {
                _context.Instituicao.Add(instituicao);
            }
            else
            {
                _context.Update(instituicao);
            }

            await _context.SaveChangesAsync();
            return instituicao;
        }

        public async Task<Instituicao> EliminarInstituicaoPorID(long id)
        {
            Instituicao instituicao = await ObterInstituicaoPorID(id);
            _context.Instituicao.Remove(instituicao);
            await _context.SaveChangesAsync();
            return instituicao;
        }
    }
}
