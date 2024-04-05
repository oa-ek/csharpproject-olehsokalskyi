using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Payments
{
    public class PaymentRepository : Repository<Payment, Guid>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext ctx) : base(ctx) { }
    }
    
}
