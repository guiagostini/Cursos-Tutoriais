﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Modelo.Discente
{
    public class Academico
    {
        [DisplayName("ID")]
        public long? AcademicoID { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("([0-9]{10})")]
        [DisplayName("Registro Academico")]
        [Required]
        public string RegistroAcademico { get; set; }

        [DisplayName("Nome")]
        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Data de Nascimento")]
        [Required]
        public DateTime? Nascimento { get; set; }

        public string FotoMimeType { get; set; }
        public  byte[] Foto { get; set; }

        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
