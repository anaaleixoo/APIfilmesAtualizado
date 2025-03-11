using API_Filmes_SENAI.Context;
using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes_SENAI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Filmes_Context _context;

        public FilmeRepository(Filmes_Context context)
        {
            _context = context;
        }


        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorID(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Filme> BuscarPorTitulo(string titulo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                // adiciona um novo genero na tabela Genero(BD)
                _context.Filme.Add(novoFilme);

                // após o cadastro, salva as alterações(BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilmes = _context.Filme
                    .Include(g => g.Genero)

                    //.Select(f => new Filme
                    //{
                    //    IdFilme = f.IdFilme,
                    //    Titulo = f.Titulo,

                    //    Genero = new Genero
                    //    {
                    //        IdGenero = f.IdGenero,
                    //        Nome = f.Genero!.Nome
                    //    }
                    //})
                    .ToList();


                return listaDeFilmes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            try
            {
                List<Filme> filmesPorGenero = _context.Filme
                    .Include(f => f.Genero) // Inclui os dados do gênero
                    .Where(f => f.IdGenero == idGenero) // Filtra os filmes pelo id do gênero
                    .ToList();

                return filmesPorGenero;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}