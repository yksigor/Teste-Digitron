using TesteDigitron.Data;
using TesteDigitron.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace TesteDigitron.Repository
{
    public class EnderecoRepository: IEnderecoRepository
    {
        private DbSession _db;

        public EnderecoRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Endereco>> GetEnderecosAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM enderecos";
                List<Endereco> enderecos = (await conn.QueryAsync<Endereco>(sql: query)).ToList();

                return enderecos;
            }
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM enderecos WHERE IdEndereco = @id";
                Endereco endereco = await conn.QueryFirstAsync<Endereco>(sql: query, param: new { id });

                return endereco;
            }
        }

        public async Task<int> SaveAsync(Endereco novoEndereco)
        {
            using (var conn = _db.Connection)
            {
                string command = "INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa)" +
                    "VALUES (@Logradouro, @CEP, @Cidade, @Estado, @IdPessoa)";

                var result = await conn.ExecuteAsync(sql: command, param: novoEndereco);
                return result;
            }
        }

        public async Task<int> UpdateEnderecoAsync(int id, Endereco atualizaEndereco)
        {
            using (var conn = _db.Connection)
            {
                string command = "UPDATE enderecos SET Logradouro = @Logradouro, CEP = @CEP, Cidade = @Cidade," +
                    " Estado = @Estado, IdPessoa = @IdPessoa WHERE IdEndereco = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.AddDynamicParams(atualizaEndereco);

                var result = await conn.ExecuteAsync(sql:command, param: parametros);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = "DELETE FROM enderecos WHERE IdEndereco = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new { id });
                return result;
            }
        }

    }
}
