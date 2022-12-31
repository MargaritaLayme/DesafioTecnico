using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ApiWebVentaComercial.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/*
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Security.Cryptography;
*/

namespace ApiWebVentaComercial.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion([FromBody] object optData)
        {
            var data=JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user =data.usuario.ToString();
            string pasword = data.password.ToString();

            Usuario usuario = Usuario.DB().Where(x=>x.usuario == user && x.pasword == pasword).FirstOrDefault();

            if (usuario == null)
            {
                return new
                {
                    sucess = true,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.idUsuario),
                new Claim("id", usuario.usuario)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(4),
                signingCredentials: singIn
                );

            return new
            {
                success = true,
                message ="exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)

            };
        }
        /*
        [HttpGet]
        [Route("listar")]
        public dynamic listarusuario()
        {
            //Todo el codigo

            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario
                {
                    idUsuario = "1",
                    usuario = "Mariana Celeste Galvez",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "2",
                    usuario = "Jorge Mamani",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "3",
                    usuario = "Alejandrra Ramirez",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "4",
                    usuario = "Juan Perez",
                    pasword = "123",
                    rol = "administrador"
                }
            };

            return usuarios;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarusuarioxid(int codigo)
        {
            //obtienes el usuario de la db

            return new Usuario
            {
                idUsuario = "1",
                usuario = "Mariana Celeste Galvez",
                pasword = "123",
                rol = "asesor"
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarusuario(Usuario usuario)
        {
            //Guardar en la db y le asignas un id
            usuario.id = "3";

            return new
            {
                success = true,
                message = "usuario registrado",
                result = usuario
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarusuario(Usuario usuario)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //eliminas en la db

            if (token != "marco123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "usuario eliminado",
                result = usuario
            };
        }
        */
    }
}
