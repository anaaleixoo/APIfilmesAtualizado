using API_Filmes_SENAI.Utils;

namespace API_Filmes_SENAI.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaInformada, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
        }
    }
}
