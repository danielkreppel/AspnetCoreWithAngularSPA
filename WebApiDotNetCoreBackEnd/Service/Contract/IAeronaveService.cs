using Common.AeronaveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IAeronaveService
    {
        Task<IEnumerable<MatriculasAeronavesViewModel>> BuscarMatriculas();
    }
}
