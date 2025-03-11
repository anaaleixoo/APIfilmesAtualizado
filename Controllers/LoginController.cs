using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API_Filmes_SENAI.Domains;
using API_Filmes_SENAI.DTO;
using API_Filmes_SENAI.Interfaces;
using API_Filmes_SENAI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_Filmes_SENAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado; email ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim
                    (JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim
                    (JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),

                    new Claim
                    (JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    new Claim
                    ("Nome da Claim", "Valor da Claim")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4º passo - Gerar o Token
                var token = new JwtSecurityToken
                (
                    // Emissor do Token
                    issuer: "API_Filmes_SENAI",

                    // Destinatário de Token
                    audience: "API_Filmes_SENAI",

                    // Dados definidos nas Claims
                    claims: claims,

                    // Tempo de expiração das Claims 
                    expires: DateTime.Now.AddMinutes(5),

                    // Credenciais do Token
                    signingCredentials: creds
                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                    }
                );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

