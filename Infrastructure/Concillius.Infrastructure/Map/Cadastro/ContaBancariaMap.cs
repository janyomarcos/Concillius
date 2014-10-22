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
    public class ContaBancariaMap : EntityMap<ContaBancaria>
    {
        public ContaBancariaMap()
        {
            this.ToTable("CONTA_BANCARIA");

            this.HasKey(c => c.Id) 
                .Property(c => c.Id)
                .HasColumnName("ID_CONTA_BANCARIA");

            this.Property(c => c.CodigoAgencia)
                .HasColumnName("ID_AGENCIA");

            this.Property(c => c.CodigoBanco)
                .HasColumnName("ID_BANCO");

            this.Property(c => c.CodigoConta)
                .HasColumnName("CODIGO_CONTA");

            this.Property(c => c.CodigoEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(c => c.ContaContabil)
                .HasColumnName("CONTA_CONTABIL");

            this.Property(c => c.ContaWeb)
                .HasColumnName("CONTA_WEB");

            this.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO");

            this.Property(c => c.Situacao)
                .HasColumnName("STATUS_CONTA_BANCARIA");

        }
    }
}
