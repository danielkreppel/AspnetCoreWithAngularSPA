using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> BuscarTodosAsync();
        Task<T> BuscarPorIdAsync(int id);
       
    }
}
