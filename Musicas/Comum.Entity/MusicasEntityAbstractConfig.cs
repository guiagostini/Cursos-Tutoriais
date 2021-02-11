using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comum.Entity
{
    public abstract class MusicasEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public MusicasEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCampoTabela();
            ConfigurarChavePrimaria();
            ConfigurarChaveEstrangeira();
        }

        protected abstract void ConfigurarChaveEstrangeira();

        protected abstract void ConfigurarChavePrimaria();

        protected abstract void ConfigurarCampoTabela();

        protected abstract void ConfigurarNomeTabela();
       
    }
}
