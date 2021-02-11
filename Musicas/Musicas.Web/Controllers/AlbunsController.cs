using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Musicas.AcessoDados.Entity.Context;
using Musicas.Dominio;
using Musicas.Repositorio.Entity;
using Musicas.Web.Filtros;
using Musicas.Web.ViewModels.Album;
using Repositorios.Comum;

namespace Musicas.Web.Controllers
{
    [Authorize]
    public class AlbunsController : Controller
    {
        private IRepositorioGenerico<Album, int> repositorioAlbum = new AlbumRepositorio(new MusicasDbContext());

        // GET: Albuns
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbum.Selecionar()));
        }
        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Album> albuns = repositorioAlbum.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<AlbumExibicaoViewModel> viewModels = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(albuns);
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Albuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbum.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumExibicaoViewModel>(album));
        }

        // GET: Albuns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbum.Inserir(album);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Albuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbum.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumViewModel>(album));
        }

        // POST: Albuns/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Observacoes")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbum.Alterar(album);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Albuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbum.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Album, AlbumExibicaoViewModel>(album));
        }

        // POST: Albuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioAlbum.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
