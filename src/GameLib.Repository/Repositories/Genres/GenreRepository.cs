﻿using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Genres
{
    public class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Genre> GetGenreByName(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return await _ctx.Genres.FirstOrDefaultAsync(g => g.Title == name);
        }
    }

}
