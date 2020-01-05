using Common.PlanoDeVooViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IPlanoVooService
    {
        Task<IEnumerable<PlanoVooViewModel>> BuscarPlanosVoos();

        Task<bool> Salvar(PlanoVooViewModel model);

        Task<bool> Excluir(PlanoVooViewModel model);

        Task<bool> NumeroVooCadastradoAsync(string numero);
    }
}
