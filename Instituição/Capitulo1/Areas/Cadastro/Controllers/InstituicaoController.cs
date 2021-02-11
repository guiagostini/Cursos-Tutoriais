using Capitulo1.Data;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capitulo1.Data.DAL.Cadastro;
using Microsoft.AspNetCore.Authorization;

namespace Capitulo1.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    [Authorize]
    public class InstituicaoController : Controller
    {
        //abrir acesso ao banco de dados com o contexto
        private readonly IESContext _context;
        private readonly InstituicaoDAL _instituicaoDAL; 

        //construtor para sempre que for acionado o controller, vim com o acesso do banco
        public InstituicaoController(IESContext context)
        {
            this._context = context;
            _instituicaoDAL = new InstituicaoDAL(context);
        }

        // GET: Instituicao
        public async Task<IActionResult> Index()
        {
            return View(await _instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToListAsync());
        }

        private async Task<IActionResult> ObterVisaoInstituicaoPorID(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await _instituicaoDAL.ObterInstituicaoPorID((long)id);
            if(instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }

        // GET: Instituicao/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoInstituicaoPorID(id);
        }

        // GET: Instituicao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _instituicaoDAL.GravarInstituicao(instituicao);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(instituicao);
        }

        // GET: Instituicao/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoInstituicaoPorID(id);
        }

        // POST: Instituicao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _instituicaoDAL.GravarInstituicao(instituicao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instituicao);
        }

        // GET: Instituicao/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoInstituicaoPorID(id);
        }

        // POST: Instituicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var instituicao = await _instituicaoDAL.EliminarInstituicaoPorID((long)id);
            TempData["Message"] = "Instituição " + instituicao.Nome.ToUpper() + " foi removida";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> InstituicaoExists(long? id)
        {
            return await _instituicaoDAL.ObterInstituicaoPorID((long)id) != null;
        }


    }
}
    
