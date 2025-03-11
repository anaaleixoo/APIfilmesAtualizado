using API_Filmes_SENAI.Domains;

namespace API_Filmes_SENAI.Interfaces
{
    /// <summary>
    /// Interface para Gênero : Contrato
    /// Toda classe que herdar (implementar) essa interface, deverá implementar TODOS OS MÉTODOS definidos aqui dentro.
    /// </summary>
    public interface IGeneroRepository
    {
        // CRUD (Acrônimo) : Métodos.
        // C : Create (Cadastrar um novo objeto).
        // R : Read (Listar todos os objetos).
        // U : Update (Alterar um objeto).
        // D : Delete (Deleto ou excluo um objeto).

        // Método = TipoDeRetorno; NomeDoMetodo (Composto por Argumentos/Parâmetros).

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Delete(Guid id);

        Genero BuscarPorID(Guid id);

    }
}
