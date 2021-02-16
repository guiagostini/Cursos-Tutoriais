
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capitulo1.Data
{
    public static class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Departamentos.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao { Nome="UTFPR", Endereco= "Medianeira"},
                new Instituicao { Nome="UFSC", Endereco = "Florianópolis"}
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicao.Add(i);
            }
            context.SaveChanges();

            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação", InstituicaoID=1 },
                new Departamento { Nome="Ciência de Alimentos", InstituicaoID=2}
            };

            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }

            context.SaveChanges();
        }
    }
}
