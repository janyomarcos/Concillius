using Concillius.Domain.Corporativo;
using Concillius.Infrastructure.Context;
using Concillius.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Application.Corporativo
{
    public class UsuarioApplication:BaseApplication<Usuario>
    {
        public UsuarioApplication()
            : base(new GenericRepository<Usuario>(new ConciliacaoContext()))
        {

        }
    }
}
