using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Publishers
{
    public class PublisherRepository : Repository<Publisher, Guid>, IPublisherRepository
    {
        public PublisherRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<Publisher> GetPublisherByName(string name)
        {
            return await Task.Run(() => _ctx.Publishers.FirstOrDefault(x => x.Title == name));
        }
    }

}
