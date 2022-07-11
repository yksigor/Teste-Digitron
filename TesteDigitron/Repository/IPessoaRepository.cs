using TesteDigitron.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDigitron.Repository
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> GetPessoasAsync();
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task<int> SaveAsync(Pessoa novaPessoa);
        Task<int> UpdatePessoaAsync(int id, Pessoa atualizaPessoa);
        Task<int> DeleteAsync(int id);
    }
}
