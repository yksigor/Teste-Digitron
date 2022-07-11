using TesteDigitron.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TesteDigitron.Repository
{
    public interface IEnderecoRepository
    {
        Task<List<Endereco>> GetEnderecosAsync();
        Task<Endereco> GetEnderecoByIdAsync(int id);
        Task<int> SaveAsync(Endereco novoEndereco);
        Task<int> UpdateEnderecoAsync(int id, Endereco atualizaEndereco);
        Task<int> DeleteAsync(int id);
    }
}
