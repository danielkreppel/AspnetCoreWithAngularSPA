using Model;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface IUnitOfWork
    {
        GenericRepository<Aeroportos> AeroportosRepository { get; }
        GenericRepository<Aeronaves> AeronavesRepository { get; }
        GenericRepository<TiposAeronaves> TiposAeronavesRepository { get; }
        GenericRepository<PlanoVoo> PlanoVooRepository { get; }
        GenericRepository<User> UsersRepository { get; }

        GenericRepository<Role> RolesRepository { get; }

        Task<int> SaveAsync();
    }
}
