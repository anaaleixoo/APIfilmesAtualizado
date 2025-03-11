using System.Linq.Expressions;
using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes_SENAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }



        /// <summary>
        /// Endpoint para POSTAR um GÊNERO pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [Authorize]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para BUSCAR um GÊNERO pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetByld(Guid id)
        {
            try
            {
                Genero generoBuscado = _generoRepository.BuscarPorID(id);

                return Ok(generoBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para DELETAR um GÊNERO pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _generoRepository.Delete(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }



            /// <summary>
            /// Endpoint para ATUALIZAR um GÊNERO pelo seu ID!
            /// </summary>
            /// <param name="id">Id do GêneroBuscado</param>
            /// <returns>Gênero Buscado</returns>
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Genero genero)
        {
            try
            {
                _generoRepository.Atualizar(id, genero);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}



