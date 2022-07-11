using TesteDigitron.Models;
using TesteDigitron.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TesteDigitron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepo;

        public PessoasController(IPessoaRepository pessoaRepo)
        {
            _pessoaRepo = pessoaRepo;
        }

        // GET: api/<PessoasController>
        [HttpGet]
        public async Task<IActionResult> GetPessoasAsync()
        {
            try
            {
                var pessoas = await _pessoaRepo.GetPessoasAsync();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PessoasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaByIdAsync(int id)
        {
            try
            {
                var pessoa = await _pessoaRepo.GetPessoaByIdAsync(id);
                if (pessoa == null)
                    return NotFound();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }        

        // POST api/<PessoasController>
        [HttpPost]
        public async Task<IActionResult> SaveAsync(Pessoa novaPessoa)
        {
            try
            {
                var resultado = await _pessoaRepo.SaveAsync(novaPessoa);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        // PUT api/<PessoasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoaAsync(int id, Pessoa atualizaPessoa)
        {
            try
            {
                var resultado = await _pessoaRepo.UpdatePessoaAsync(id, atualizaPessoa);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PessoasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var resultado = await _pessoaRepo.DeleteAsync(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}