﻿using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Achievements
{
    public class AchievementRepository : Repository<Achievement, Guid>, IAchievementRepository
    {
        public AchievementRepository(AppDbContext ctx) : base(ctx) { }

    }
}
