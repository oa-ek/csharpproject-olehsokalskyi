using Application.Extentios;
using Domain.Entities;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class LanguageRepository : Repository<Language, Guid>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext ctx) : base(ctx) { }
    }

}
