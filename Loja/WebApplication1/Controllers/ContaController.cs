using Store.Data.EF.Repositories;
using Store.Domain.Contracts.Repositories;
using Store.Domain.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.ViewModels.Conta.Login;

namespace Store.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ContaController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginVM() { ReturnUrl = returnUrl };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var usuario = _usuarioRepository.Get(model.Email);
            if (usuario == null)
            {
                ModelState.AddModelError("Email", "Email não localizado");
            }
            else
            {
                if(usuario.Senha != model.Senha.Encrypt())
                {
                    ModelState.AddModelError("Senha", "Senha inválida");
                }
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
           
        }
    }
}
