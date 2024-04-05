using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Languages
{
    public class LanguageRepository : Repository<Language, Guid>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext ctx) : base(ctx) { }
    }
   
}
