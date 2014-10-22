using Concillius.Domain.Cadastros;
using Concillius.Infrastructure.Map.Corporativo;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Map.Cadastro
{
    public class ItemParametroAdministradoraMap : EntityMap<ItemParametroAdministradora>
    {
        public ItemParametroAdministradoraMap()
        {
            this.ToTable("PARAMETRO_ADMINISTRADORA_DET");

            this.HasKey(i => i.Id)
                .Property(i => i.Id)
                .HasColumnName("ID_PARAMETRO_ADMINISTRADORA_DET");

            this.Property(i => i.IdParametroAdministradora)
                .HasColumnName("ID_PARAMETRO_ADMINISTRADORA_CAB");

            this.Property(i => i.NumeroParcela)
                .HasColumnName("NUMERO_PARCELA");

            this.Property(i => i.Taxa)
                .HasColumnName("TAXA");

        }
    }
}
