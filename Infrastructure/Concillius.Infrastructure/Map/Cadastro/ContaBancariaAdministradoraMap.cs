using Concillius.Domain.Cadastros;
using Concillius.Infrastructure.Map.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Map.Cadastro
{
    public class ContaBancariaAdministradoraMap:EntityMap<ContaBancariaAdministradora>
    {
        public ContaBancariaAdministradoraMap()
        {
            this.ToTable("CONTA_BANCARIA_ADMINISTRADORA");

            this.HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("ID_CONTA_BANCARIA_ADMINISTRADORA");

            this.Property(c => c.IdAdministradoraCartao)
                .HasColumnName("ID_ADMINISTRADORA");

            this.Property(a => a.IdContaBancaria)
                .HasColumnName("ID_CONTA_BANCARIA");

            this.Property(c => c.IdEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(c => c.Situacao)
                .HasColumnName("STATUS_CONTA_BANCARIA_ADMINISTRADORA");

        }
    }
}
