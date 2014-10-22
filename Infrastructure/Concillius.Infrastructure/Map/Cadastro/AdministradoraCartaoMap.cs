using Concillius.Domain.Corporativo;
using Concillius.Domain.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Map.Cadastro
{
    public class AdministradoraCartaoMap : EntityTypeConfiguration<AdministradoraCartao>
    {
        public AdministradoraCartaoMap()
        {
            this.ToTable("ADMINISTRADORA_CARTAO");

            this.HasKey(a => new { a.Id, a.IdEmpresa });

            this.Property(a => a.Id)
                .HasColumnName("ID_ADMINISTRADORA");

            this.Property(a => a.IdEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(a => a.IdRegraGerarVencimento)
                .HasColumnName("ID_REGRA_GERAR_VENCIMENTO");

            this.Property(a => a.ImportaAjusteFinanceiro)
                .HasColumnName("FLAG_IMPORTA_AJUSTE_FINANCEIRO");

            this.Property(a => a.ImportaAjusteVenda)
                .HasColumnName("FLAG_IMPORTA_AJUSTE_VENDA");

            this.Property(a => a.ImportarAntecipacao)
                .HasColumnName("IMPORTA_ANTECIPACAO");

            this.Property(a => a.ImportarArquivoVencimentoFinanceiroJuntos)
                .HasColumnName("IMPORTA_ARQUIVO_VENFIN_JUNTOS");

            this.Property(a => a.NomeCartao)
                .HasColumnName("NOME_CARTAO");

            this.Property(a => a.NomePasta)
                .HasColumnName("NOME_PASTA");

            this.Property(a => a.NumeroMaximoParcelas)
                .HasColumnName("NUMERO_PARCELAS");

            this.Property(a => a.RazaoSocial)
                .HasColumnName("RAZAO_SOCIAL");

            this.Property(a => a.Situacao)
                .HasColumnName("STATUS_ADMINISTRADORA");

            this.Property(a => a.SomarFeriado)
                .HasColumnName("FLAG_SOMAR_FERIADO");

            this.Property(a => a.TipoCartao)
                .HasColumnName("TIPO_CARTAO");

            this.Property(a => a.TipoUniao)
                .HasColumnName("TIPO_UNIAO");

            this.Property(a => a.Versao)
                .HasColumnName("CT_LOCK");

            this.Property(a => a.CNPJ)
                .HasColumnName("CNPJ");

            this.Property(a => a.CodigoCliente)
                .HasColumnName("CODIGO_CLIENTE");

            this.Property(a => a.CodigoControle)
                .HasColumnName("CODIGO_CONTROLE");

            this.Property(a => a.CodigoLayout)
                .HasColumnName("ID_LAYOUT");

            this.Property(a => a.CodigoUsuarioAlteracao)
                .HasColumnName("USUARIO_ALTERACAO");

            this.Property(a => a.CodigoUsuarioInclusao)
                .HasColumnName("USUARIO_INCLUSAO");

            this.Property(a => a.CodigoUsuarioResponsavel)
                .HasColumnName("USUARIO_RESPONSAVEL");

            this.Property(a => a.DataAlteracao)
                .HasColumnName("DATA_ALTERACAO");

            this.Property(a => a.DataInclusao)
                .HasColumnName("DATA_INCLUSAO");

            this.Property(a => a.DiaMesCredito)
                .HasColumnName("DIA_MES_CREDITO");

            this.Property(a => a.DuplicarCarga)
                .HasColumnName("FLAG_DUPLICACAO_CARGA");

            this.Property(a => a.Gerar)
                .HasColumnName("FLAG_GERACAO");
        }
    }
}
