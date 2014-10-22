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
    public class FilialMap : EntityMap<Filial>
    {
        public FilialMap()
        {
            this.ToTable("FILIAL");

            this.HasKey(f => new {f.Codigo,f.CodigoEmpresa});

            this.Property(f => f.Codigo)
                .HasColumnName("ID_FILIAL");

            this.Property(f => f.CodigoEmpresa)
                .HasColumnName("ID_EMPRESA");

            this.Property(f => f.CodigoFilialERP)
                .HasColumnName("ID_FILIAL_ERP");

            this.Property(f => f.DataAbertura)
                .HasColumnName("DATA_ABERTURA");

            this.Property(f => f.Endereco)
                .HasColumnName("ENDERECO");

            this.Property(f => f.NomeFilial)
                .HasColumnName("NOME_FILIAL");

            this.Property(f => f.NumeroLogradouro)
                .HasColumnName("NUMERO");

            this.Property(f => f.Sigla)
                .HasColumnName("SIGLA");

            this.Property(f => f.UF)
                .HasColumnName("UF");

            this.Property(f => f.Bairro)
                .HasColumnName("BAIRRO");

            this.Property(f => f.Cep)
                .HasColumnName("CEP");

            this.Property(f => f.CGC)
                .HasColumnName("CGC");

            this.Property(f => f.Cidade)
                .HasColumnName("CIDADE");

        }
    }
}
