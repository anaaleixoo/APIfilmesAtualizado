using API_Filmes_SENAI.Domains;

namespace API_Filmes_SENAI.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filme novoFilme);

        List<Filme> Listar();

        void Atualizar(Guid id, Filme filme);

        void Deletar(Guid id);

        Filme BuscarPorId(Guid id);

        // Listar os filmes pelo seu gênero!
        List<Filme> ListarPorGenero(Guid idGenero);
        Filme BuscarPorID(Guid id);
        List<Filme> BuscarPorTitulo(string titulo);
    }
}
