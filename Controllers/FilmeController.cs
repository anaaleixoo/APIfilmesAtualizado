using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes_SENAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }



        /// <summary>
        /// Endpoint para LISTAR um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();

                return Ok(listaDeFilmes);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para POSTAR um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para BUSCAR um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>
      
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);
                return Ok(filmeBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para DELETAR um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para ATUALIZAR um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para LISTAR por GÊNERO um FILME pelo seu ID!
        /// </summary>
        /// <param name="id">Id do GêneroBuscado</param>
        /// <returns>Gênero Buscado</returns>


        [HttpGet("genero/{idGenero}")]
        public IActionResult ListarPorGenero(Guid idGenero)
        {
            var filmes = _filmeRepository.ListarPorGenero(idGenero);

            if (filmes == null || !filmes.Any())
                return NotFound("Nenhum filme encontrado para esse gênero.");

            return Ok(filmes);
        }

    }
}


