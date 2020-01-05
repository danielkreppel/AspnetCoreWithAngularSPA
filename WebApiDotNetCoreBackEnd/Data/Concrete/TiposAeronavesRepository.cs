using Domain.Entities;
using Data.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common.Log.Contract;

namespace Data.Concrete
{
    public class TiposAeronavesRepository : ITiposAeronavesRepository
    {
        private IConnectionFactory _conn;
        private ILog _log;
        public TiposAeronavesRepository(IConnectionFactory conn, ILog log){
            _conn = conn;
            _log = log;
        }

        public async Task<TipoAeronave> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<TipoAeronave>("BUSCAR_TIPOS_AERONAVES", new { IDAERONAVE = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<IEnumerable<TipoAeronave>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<TipoAeronave>("BUSCAR_TIPOS_AERONAVES", commandType: System.Data.CommandType.StoredProcedure);
                    return lista;
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

    }

}
