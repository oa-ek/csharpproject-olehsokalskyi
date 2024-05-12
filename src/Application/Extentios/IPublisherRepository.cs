
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IRepositories
{
    public interface IPublisherRepository : IRepository<Publisher, Guid>
    {
        public Task<Publisher> GetPublisherByName(string name);
    }
}
