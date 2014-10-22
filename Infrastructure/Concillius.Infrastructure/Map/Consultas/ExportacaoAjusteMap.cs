using Concillius.Domain.Cadastros;
using Concillius.Domain.Consultas;
using Concillius.Infrastructure.Map.Corporativo;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Map.Cadastro
{
    public class ExportacaoAjusteMap : EntityTypeConfiguration<ExportacaoAjusteDTO>
    {
        public ExportacaoAjusteMap()
        {
            this.ToTable("vw_Ajuste");
        }
    }
}
