using Chapter.WebApi.Interface;
using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public UsuarioController(IUsuarioRepository UsuarioRepository)
        {
            _iUsuarioRepository = UsuarioRepository;
        }
        [HttpGet]
        public IActionResult Buscar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")] 
        public IActionResult BuscarporId(int id)
        {
            try
            {
                return Ok(_iUsuarioRepository.GetById(id));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return StatusCode(204);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }

}