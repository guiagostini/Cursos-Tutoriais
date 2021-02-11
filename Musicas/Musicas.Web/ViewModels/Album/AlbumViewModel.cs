using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "O ID do álbum é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do álbum é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome do álbum poderá ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Álbum")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O ano do álbum é obrigatório")]
        [Display(Name = "Ano do Álbum")]
        public int Ano { get; set; }

        [MaxLength(1000, ErrorMessage = "Excedeu o número máximo de 1000 caracteres para observação")]
        [Display(Name = "Observações sobre o Álbum")]
        public string Observacoes { get; set; }
    }
}