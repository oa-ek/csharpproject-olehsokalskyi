﻿using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Platforms
{
    public class PlatformRepository : Repository<Platform, Guid>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext ctx) : base(ctx) { }
    }

}
