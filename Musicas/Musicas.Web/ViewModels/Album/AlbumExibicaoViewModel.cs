using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicas.Web.ViewModels.Album
{
    public class AlbumExibicaoViewModel
    {
        
        public int Id { get; set; }

        [Display(Name = "Nome do Album")]
        public string Nome { get; set; }

        [Display(Name = "Ano do Album")]
        public int Ano { get; set; }

        [Display(Name = "Observações sobre o Album")]
        public string Observacoes { get; set; }
    }
}