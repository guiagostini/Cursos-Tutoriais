using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Conta.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "Limite do {0} é de {1} caracteres")]
        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "{0} inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "Limite do {0} é de {1} caracteres")]
        public string Senha { get; set; }

        public bool PermanecerLogado { get; set; }
        public string ReturnUrl { get; set; }
    }
}
