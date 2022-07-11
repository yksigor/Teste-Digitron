using TesteDigitron.Models;
using TesteDigitron.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace TesteDigitron.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private DbSession _db;
        public PessoaRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM pessoas";
                List<Pessoa> pessoas = (await conn.QueryAsync<Pessoa>(sql: query)).ToList();

                return pessoas;
            }
        }

        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM pessoas WHERE IdPessoa = @id";
                Pessoa pessoa = await conn.QueryFirstOrDefaultAsync<Pessoa>
                    (sql: query, param: new { id });

                return pessoa;
            }
        }

        public async Task<int> SaveAsync(Pessoa novaPessoa)
        {
            using (var conn = _db.Connection)
            {
                string command = "INSERT INTO pessoas(Nome, Telefone, CPF)" +
                    "VALUES (@Nome, @Telefone, @CPF)";
                
                var result = await conn.ExecuteAsync(sql: command, param: novaPessoa);
                return result;
            }
        }

        public async Task<int> UpdatePessoaAsync(int id, Pessoa atualizaPessoa)
        {
            using (var conn = _db.Connection)
            {
                string command = "UPDATE pessoas SET Nome = @Nome, Telefone = @Telefone, CPF = @CPF WHERE IdPessoa = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.AddDynamicParams(atualizaPessoa);

                var result = await conn.ExecuteAsync(sql: command, param: parametros);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = "DELETE FROM pessoas WHERE IdPessoa = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new { id });
                return result;
            }
        }
    }
}
