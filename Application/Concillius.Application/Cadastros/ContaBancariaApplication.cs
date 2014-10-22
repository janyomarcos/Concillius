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
    public class ContaBancariaApplication : BaseApplication<ContaBancaria>
    {
        public ContaBancariaApplication()
            : base(new GenericRepository<ContaBancaria>(new ConciliacaoContext()))
        {

        }
    }
}
