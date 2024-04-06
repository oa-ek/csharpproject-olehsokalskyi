using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Discounts
{
    public class DiscountRepository : Repository<Discount, Guid>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext ctx) : base(ctx) { }
    }

}
