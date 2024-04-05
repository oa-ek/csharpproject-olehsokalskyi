using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Ratings
{
    public class RatingRepository : Repository<Rating, Guid>, IRatingRepository
    {
        public RatingRepository(AppDbContext ctx) : base(ctx) { }
    }
    
}
