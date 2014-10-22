using Concillius.Domain.Corporativo;
using Concillius.Infrastructure.Map.Cadastro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Context
{
    public class ConciliacaoContext : DbContext
    {
        public ConciliacaoContext():base("ConciliacaoContext")
        {
            Database.SetInitializer<ConciliacaoContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ContaBancariaMap());
            modelBuilder.Configurations.Add(new ContaBancariaAdministradoraMap());
            modelBuilder.Configurations.Add(new FilialMap());
            modelBuilder.Configurations.Add(new MaquinetaCartaoMap());
            modelBuilder.Configurations.Add(new ParametroAdministradoraMap());
            modelBuilder.Configurations.Add(new ItemParametroAdministradoraMap());
            modelBuilder.Configurations.Add(new AdministradoraCartaoMap());
        }
        
    }
}
