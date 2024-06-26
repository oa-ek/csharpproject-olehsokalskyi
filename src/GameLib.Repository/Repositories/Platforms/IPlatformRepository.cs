﻿using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Platforms
{
    public interface IPlatformRepository : IRepository<Platform, Guid>
    {
        public Task<Platform> GetPlatformByName(string name);

    }
}
