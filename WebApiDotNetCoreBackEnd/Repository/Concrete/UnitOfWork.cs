using Model;
using Repository.Concrete;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDBContext _context; 

        private GenericRepository<Aeroportos> _aeroportosRepository;
        private GenericRepository<Aeronaves> _aeronavesRepository;
        private GenericRepository<TiposAeronaves> _tiposAeronavesRepository;
        private GenericRepository<PlanoVoo> _planoVooRepository;
        private GenericRepository<User> _usersRepository;
        private GenericRepository<Role> _rolesRepository;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public GenericRepository<Aeroportos> AeroportosRepository {
            get
            {
                if (_aeroportosRepository == null) {
                    _aeroportosRepository = new GenericRepository<Aeroportos>(_context);
                }
                return _aeroportosRepository;
            }
        }

        public GenericRepository<Aeronaves> AeronavesRepository
        {
            get
            {
                if (_aeronavesRepository == null)
                {
                    _aeronavesRepository = new GenericRepository<Aeronaves>(_context);
                }
                return _aeronavesRepository;
            }
        }

        public GenericRepository<TiposAeronaves> TiposAeronavesRepository
        {
            get
            {
                if (_tiposAeronavesRepository == null)
                {
                    _tiposAeronavesRepository = new GenericRepository<TiposAeronaves>(_context);
                }
                return _tiposAeronavesRepository;
            }
        }

        public GenericRepository<PlanoVoo> PlanoVooRepository
        {
            get
            {
                if (_planoVooRepository == null)
                {
                    _planoVooRepository = new GenericRepository<PlanoVoo>(_context);
                }
                return _planoVooRepository;
            }
        }

        public GenericRepository<User> UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new GenericRepository<User>(_context);
                }
                return _usersRepository;
            }
        }

        public GenericRepository<Role> RolesRepository
        {
            get
            {
                if (_rolesRepository == null)
                {
                    _rolesRepository = new GenericRepository<Role>(_context);
                }
                return _rolesRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
