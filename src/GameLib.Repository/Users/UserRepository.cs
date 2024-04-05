using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(AppDbContext ctx) : base(ctx) { }
    }
   
}
