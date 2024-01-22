using CrudDeProduto.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CrudDeProduto.Data
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuracoes.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                /**/
            }

        }
    }
}
