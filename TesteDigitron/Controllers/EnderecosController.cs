using TesteDigitron.Models;
using TesteDigitron.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TesteDigitron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepo;

        public EnderecosController(IEnderecoRepository enderecoRepo)
        {
            _enderecoRepo = enderecoRepo;
        }

        // GET: api/<EnderecosController>
        [HttpGet]
        public async Task<IActionResult> GetEnderecosAsync()
        {
            try
            {
                var enderecos = await _enderecoRepo.GetEnderecosAsync();
                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        // GET api/<EnderecosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnderecoByIdAsync(int id)
        {
            try
            {
                var endereco = await _enderecoRepo.GetEnderecoByIdAsync(id);
                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        // POST api/<EnderecosController>
        [HttpPost]
        public async Task<IActionResult> SaveAsync(Endereco novoEndereco)
        {
            try
            {
                var resultado = await _enderecoRepo.SaveAsync(novoEndereco);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<EnderecosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnderecoAsync(int id, Endereco atualizaEndereco)
        {
            try
            {
                var resultado = await _enderecoRepo.UpdateEnderecoAsync(id, atualizaEndereco);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        // DELETE api/<EnderecosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var resultado = await _enderecoRepo.DeleteAsync(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }
    }
}