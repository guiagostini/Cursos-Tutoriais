using Store.Data.ADO.Repositories;
using Store.Data.EF;
using Store.Data.EF.Repositories;
using Store.Domain.Contracts.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<StoreDataContextEF>();
            container.RegisterType<IProdutoRepository, ProdutoRepositoryEF>();
            container.RegisterType<ITipoProdutoRepository, TipoProdutoRepositoryEF>();
            container.RegisterType<IUsuarioRepository, UsuarioRepositoryEF>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}