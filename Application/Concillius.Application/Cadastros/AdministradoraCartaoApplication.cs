using Concillius.Application.Corporativo;
using Concillius.Domain.Cadastros;
using Concillius.Infrastructure.Context;
using Concillius.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Application.Cadastros
{
    public class AdministradoraCartaoApplication:BaseApplication<AdministradoraCartao>
    {
        public AdministradoraCartaoApplication()
            : base(new GenericRepository<AdministradoraCartao>(new ConciliacaoContext()))
        {

        }
    }
}
