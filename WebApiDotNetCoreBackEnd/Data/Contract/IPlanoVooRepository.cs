using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contract
{
    public interface IPlanoVooRepository : IGenericRepository<PlanoVoo>
    {
        Task<bool> RemoverAsync(PlanoVoo entidade);
        Task<bool> AtualizarAsync(PlanoVoo entidade);
        Task<bool> InserirAsync(PlanoVoo entidade);
        Task<bool> NumeroVooCadastradoAsync(string numero);
    }
}
