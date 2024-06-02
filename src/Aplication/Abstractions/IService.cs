using Application.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IService< T1, T2, T3>
    {
        Task<DefaultMessageResponse> AddAsync(T2 model);
        Task<T1> GetByIdAsync(Guid id);
        Task<IEnumerable<T1>> GetListAsync();
        Task<DefaultMessageResponse> UpdateAsync(T3 model);
        Task<DefaultMessageResponse> DeleteAsync(Guid id);
    }
}
