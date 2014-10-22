using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Map.Corporativo
{
    public class EntityMap<T>:EntityTypeConfiguration<T> where T: Entity
    {
        
        public EntityMap ()
	    {
            this.Property(e => e.Versao)
                    .HasColumnName("CT_LOCK");

            this.Property(e => e.CodigoUsuarioAlteracao)
                .HasColumnName("USUARIO_ALTERACAO");

            this.Property(e => e.CodigoUsuarioInclusao)
                .HasColumnName("USUARIO_INCLUSAO");

            this.Property(e => e.DataAlteracao)
                .HasColumnName("DATA_ALTERACAO");

            this.Property(e => e.DataInclusao)
                .HasColumnName("DATA_INCLUSAO");
	    }
    }
}
