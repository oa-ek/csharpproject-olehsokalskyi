
using Application.Abstractions.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
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
