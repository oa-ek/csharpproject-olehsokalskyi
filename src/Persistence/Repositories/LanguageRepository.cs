
using Application.Abstractions.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LanguageRepository : Repository<Language, Guid>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext ctx) : base(ctx) { }
    }

}
