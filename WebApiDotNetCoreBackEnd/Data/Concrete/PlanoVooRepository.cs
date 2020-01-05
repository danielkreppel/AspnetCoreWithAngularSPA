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
    public class PlanoVooRepository : IPlanoVooRepository
    {
        private IConnectionFactory _conn;
        private ILog _log;
        public PlanoVooRepository(IConnectionFactory conn, ILog log){
            _conn = conn;
            _log = log;
        }

        public async Task<bool> InserirAsync(PlanoVoo entidade)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("EXEC INSERIR_PLANO_VOO @NUMEROVOO, @DATA, @IDAERONAVE, @IDAEROPORTOORIGEM, @IDAEROPORTODESTINO", entidade);
                    return true;
                }
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }

        public async Task<bool> AtualizarAsync(PlanoVoo entidade)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("EXEC ATUALIZAR_PLANO_VOO @IDPLANOVOO, @NUMEROVOO, @DATA, @IDAERONAVE, @IDAEROPORTOORIGEM, @IDAEROPORTODESTINO", entidade);
                    return true;
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }

        public async Task<PlanoVoo> BuscarPorIdAsync(int id)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<PlanoVoo>("BUSCAR_PLANO_VOO", new { IDPLANOVOO = id }, commandType: System.Data.CommandType.StoredProcedure);
                    return lista.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<bool> NumeroVooCadastradoAsync(string numero)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var qtde = await conn.QueryAsync<int>("SELECT COUNT(*) FROM PLANO_VOO WHERE NUMEROVOO = @NUMEROVOO AND ATIVO=1", new { NUMEROVOO = numero });
                    return qtde.FirstOrDefault() > 0;
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                throw;
            }
        }

        public async Task<IEnumerable<PlanoVoo>> BuscarTodosAsync()
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    var lista = await conn.QueryAsync<PlanoVoo>("BUSCAR_PLANO_VOO", commandType: System.Data.CommandType.StoredProcedure);
                    return lista;
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<bool> RemoverAsync(PlanoVoo entidade)
        {
            try
            {
                using (var conn = _conn.GetConnection())
                {
                    await conn.ExecuteAsync("EXEC EXCLUIR_PLANO_VOO @IDPLANOVOO", entidade);
                    return true;
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }
    }

}
