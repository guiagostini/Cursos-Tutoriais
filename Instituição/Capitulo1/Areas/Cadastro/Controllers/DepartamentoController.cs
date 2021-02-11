
using Capitulo1.Data;
using Modelo.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capitulo1.Data.DAL.Cadastro;

namespace Capitulo1.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;
        private readonly DepartamentoDAL _departamentoDAL;
        private readonly InstituicaoDAL _instituicaoDAL;

        public DepartamentoController(IESContext context)
        {
            this._context = context;
            _instituicaoDAL = new InstituicaoDAL(context);
            _departamentoDAL = new DepartamentoDAL(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _departamentoDAL.ObterDepartamentosClassificadosPorNome().ToListAsync());
        }


        public IActionResult Create()
        {
            var instituicoes = _instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList();
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a instituição" });
            ViewBag.Instituicoes = instituicoes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, InstituicaoID")] Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departamentoDAL.GravarDepartamento(departamento);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(departamento);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult visaoDepartamento = (ViewResult)await ObterVisaoDepartamentoPorId(id);
            Departamento departamento = (Departamento)visaoDepartamento.Model;

            ViewBag.Instituicoes = new SelectList(_instituicaoDAL.ObterInstituicoesClassificadasPorNome(), "InstituicaoID", "Nome", departamento.InstituicaoID);
            return visaoDepartamento;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DepartamentoID, Nome, InstituicaoID")] Departamento departamento)
        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departamentoDAL.GravarDepartamento(departamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await DepartamentoExists(departamento.DepartamentoID))
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

            ViewBag.Instituicoes = new SelectList(_instituicaoDAL.ObterInstituicoesClassificadasPorNome(), "InstituicaoID", "Nome", departamento.InstituicaoID);

            return View(departamento);
        }

        private async Task<bool> DepartamentoExists(long? id)
        {
            return await _departamentoDAL.ObterDepartamentoPorId((long)id) != null;
        }

        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoDepartamentoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoDepartamentoPorId(id);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var departamento = await _departamentoDAL.EliminarDepartamentoPorId((long)id);
            TempData["Message"] = "Departamento " + departamento.Nome.ToUpper() + " foi removido";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> ObterVisaoDepartamentoPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var departamento = await _departamentoDAL.ObterDepartamentoPorId((long)id);
            if(departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

    }
    
}
