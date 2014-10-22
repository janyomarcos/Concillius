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
    public class ParametroAdministradoraMap : EntityMap<ParametroAdministradora>
    {
        public ParametroAdministradoraMap()
        {
            this.ToTable("PARAMETRO_ADMINISTRADORA_CAB");

            this.HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasColumnName("ID_PARAMETRO_ADMINISTRADORA_CAB");

            this.Property(p => p.BaseParcelaAnterior)
                .HasColumnName("FLAG_BASE_PARCELA_ANTERIOR");

            this.Property(p => p.CodigoEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(p => p.DataParcela1)
                .HasColumnName("FLAG_DATA_PARCELA1");

            this.Property(p => p.DataVigencia)
                .HasColumnName("DATA_VIGENCIA");

            this.Property(p => p.Desativado)
                .HasColumnName("DESATIVADO");

            this.Property(p => p.DiasAdministracaoTrafego)
                .HasColumnName("FLAG_DIAS_ADM_TRAFEGO");

            this.Property(p => p.DiaSemanaCredito)
                .HasColumnName("DIA_SEMANA_CREDITO");

            this.Property(p => p.IdAdministradora)
                .HasColumnName("ID_ADMINISTRADORA");

            this.HasMany(p => p.Itens)
                .WithRequired()
                .HasForeignKey(i => i.IdParametroAdministradora)
                .WillCascadeOnDelete(true);

            this.Property(p => p.MesAnterior)
                .HasColumnName("FLAG_MES_ANTERIOR");

            this.Property(p => p.MesCredito)
                .HasColumnName("FLAG_MES_CREDITO");

            this.Property(p => p.QuantidadeDiasParcela1)
                .HasColumnName("QUANTIDADE_DIAS_PARCELA_1");

            this.Property(p => p.QuantidadeDiasParcelado)
                .HasColumnName("QUANTIDADE_DIAS_PARCELADO");

            this.Property(p => p.QuantidadeDiasRotativo)
                .HasColumnName("QUANTIDADE_DIAS_ROTATIVO");

            this.Property(p => p.ValorDocumento)
                .HasColumnName("VALOR_DOCUMENTO");

            this.Property(p => p.ValorSaldoInicial)
                .HasColumnName("VALOR_SALDO_INICIAL");

        }
    }
}
