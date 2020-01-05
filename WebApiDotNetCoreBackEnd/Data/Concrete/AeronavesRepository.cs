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
    public class AeronavesRepository : IAeronavesRepository
    {
        private IConnectionFactory _conn;
        private ILog _log;
        public AeronavesRepository(IConnectionFactory conn, ILog log){
            _conn = conn;
            _log = log;
        }

        public async Task<Aeronave> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeronave>("BUSCAR_AERONAVES", new { IDAERONAVE = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<IEnumerable<Aeronave>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<Aeronave>("BUSCAR_AERONAVES", commandType: System.Data.CommandType.StoredProcedure);
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
