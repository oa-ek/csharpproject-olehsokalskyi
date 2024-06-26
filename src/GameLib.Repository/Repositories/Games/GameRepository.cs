﻿using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Games
{
    public class GameRepository : Repository<Game, Guid>, IGameRepository
    {
        public GameRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Game> ExitGameByName(string name)
        {
            if (name == null) 
                throw new ArgumentNullException(nameof(name));

            return await _ctx.Games.FirstOrDefaultAsync(g => g.Title == name);

        }

        public async  Task<List<Game>> GetGamesByUserIdAsync(Guid userId)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            return user.Games.ToList();
        }
    }

}
