
using API_Filmes_SENAI.Context;
using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.Interfaces;

namespace API_Filmes_SENAI.Repositories
{

    // classe que vai implementar a interface IGeneroRepository
    // ou seja, vamos implementar os metodos, toda a logica dos metodos
    public class GeneroRepository : IGeneroRepository
    {

        // variavel privada somente a leitura que "guarda" os dados do contexto
        private readonly Filmes_Context _context;


        // construtor do repositorio

        public GeneroRepository(Filmes_Context contexto)
        {

            _context = contexto;

        }

        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;
                if (generoBuscado != null)
                {
                    generoBuscado.Nome = genero.Nome;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Genero BuscarPorID(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                return generoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

  

        // metodo para cadastrar um novo genero
        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                // adiciona um novo genero na tabela Genero(BD)
                _context.Genero.Add(novoGenero);

                // após o cadastro, salva as alterações(BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    _context.Genero.Remove(generoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Genero> Listar()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            List<Genero> ListaGeneros = _context.Genero.ToList();

            return ListaGeneros;
        }
    }
}