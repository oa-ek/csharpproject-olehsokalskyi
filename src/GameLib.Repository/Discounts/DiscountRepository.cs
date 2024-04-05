using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Discounts
{
    public class DiscountRepository : Repository<Discount, Guid>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext ctx) : base(ctx) { }
    }
   
}
