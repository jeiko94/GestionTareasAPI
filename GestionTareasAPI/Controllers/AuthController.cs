using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionTareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Este es un ejemplo simplificado. En producción, usa una base de datos y almacena contraseñas de forma segura.
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            // Validar el usuario (esto es solo un ejemplo)
            if (user.Username == "admin" && user.Password == "password")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("TuClaveSecretaMuyLargaParaSeguridad"); // Debe coincidir con la clave en Program.cs

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(new { Token = jwtToken });
            }

            return Unauthorized("Credenciales inválidas, no invente mijo y valla a robar a otra parte");
        }
    }

    /// <summary>
    /// Modelo para el inicio de sesión de usuarios.
    /// </summary>
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
