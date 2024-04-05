using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Payments
{
    public interface IPaymentRepository : IRepository<Payment, Guid>
    {
    }
}
