using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Genres
{
    public interface IGenreRepository : IRepository<Genre, Guid>
    {
    }
}
