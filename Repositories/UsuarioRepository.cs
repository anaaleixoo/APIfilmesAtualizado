using API_Filmes_SENAI.Context;
using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.Interfaces;
using API_Filmes_SENAI.Migrations;
using API_Filmes_SENAI.Utils;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes_SENAI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Filmes_Context _context;

        public UsuarioRepository(Filmes_Context Context)
        {
            _context = Context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {

                Usuario usuarioBuscado = _context.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                   bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                    return null!;  
           
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;

                if(usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                _context.Usuario.Add(novoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
