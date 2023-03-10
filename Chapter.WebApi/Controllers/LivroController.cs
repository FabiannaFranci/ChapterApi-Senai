using Chapter.WebApi.Interface;
using Chapter.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _iLivroRepository;
        public LivroController(ILivroRepository iLivroRepository)
        {
            _iLivroRepository = iLivroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iLivroRepository.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _iLivroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(int id,Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204); 
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_iLivroRepository.BuscarPorId(id));
            }
            catch (Exception e )
            {

                throw new Exception(e.Message);
            }
        }
       
        
    }
}
