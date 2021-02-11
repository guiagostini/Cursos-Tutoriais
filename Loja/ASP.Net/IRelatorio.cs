using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LojaLivro
{
    public interface IRelatorio
    {
        Task Imprimir(HttpContext context);
    }
}