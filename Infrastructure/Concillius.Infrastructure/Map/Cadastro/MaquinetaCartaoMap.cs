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
    public class MaquinetaCartaoMap : EntityMap<MaquinetaCartao>
    {
        public MaquinetaCartaoMap()
        {
            this.ToTable("MAQUINETA_CARTAO");

            this.HasKey(m => m.Id)
                .Property(m => m.Id)
                .HasColumnName("ID_MAQUINETA");

            this.Property(m => m.IdAdministradora)
                .HasColumnName("ID_ADMINISTRADORA");

            this.Property(m => m.Codigo)
                .HasColumnName("CODIGO_MAQUINETA");

            this.Property(m => m.CodigoEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(m => m.CodigoFilial)
                .HasColumnName("ID_FILIAL");

            this.Property(m => m.GravarCupom)
                .HasColumnName("FLAG_GRAVAR_CUPOM");

            this.Property(m => m.ImportarCupomDetalhado)
                .HasColumnName("IMPORTA_CUPOM_DETALHADO");

            this.Property(m => m.NumeroTerminal)
                .HasColumnName("NUMERO_TERMINAL");

            this.Property(m => m.Situacao)
                .HasColumnName("STATUS_MAQUINETA");

            this.Property(m => m.Tipo)
                .HasColumnName("TIPO_MAQUINETA");

        }
    }
}
