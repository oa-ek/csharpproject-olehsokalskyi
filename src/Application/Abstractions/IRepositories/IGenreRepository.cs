
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IRepositories
{
    public interface IGenreRepository : IRepository<Genre, Guid>
    {
        public Task<Genre> GetGenreByName(string name);
    }
}
