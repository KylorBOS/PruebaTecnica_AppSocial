using Microsoft.AspNetCore.Mvc;


using SocialAPI.Dominio;
using SocialAPI.Aplicaciones.Interfaces;
using SocialAPI.Dominio.Interfaces.Repositorios;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialAPI.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService<Usuario, Guid> servicio;
        private readonly IRepositorioUser<Usuario, Guid> repositorio;

        public UserController(IUsuarioService<Usuario, Guid> _servicio, IRepositorioUser<Usuario, Guid> _repositorio)
        {
            servicio = _servicio;
            repositorio = _repositorio;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult ListarPorID(Guid id)
        {
            return Ok(servicio.SelectPorID(id));
        }

        // POST api/<UserController>
        [HttpPost("create")]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            servicio.Agregar(usuario);
            return Ok("Usuario creado!!");
        }

        // PUT api/<UserController>/5
        [HttpPut(("{id}"))]
        public IActionResult ActualizarUsuario(Guid id, [FromBody] Usuario usuario)
        {
            usuario.UsuarioId = id;
            servicio.Actualizar(usuario);
            return Ok("Usuario actualizado correctamente!!");
        }

        // POST api/<UserController>
        [HttpPost("post/{nombre}")]
        public IActionResult Post(string nombre, [FromBody] string texto)
        {
            servicio.PublicarPost(nombre, texto);
            return Ok($"{nombre} acaba de postear");
        }

        [HttpPost("follow/{nombreSeguidor}/{nombreSeguido}")]
        public IActionResult Follow(string nombreSeguidor, string nombreSeguido)
        {
            var usuarioDestino = repositorio.ObtenerPorNombre(nombreSeguido);

            if (usuarioDestino == null)
            {
                return NotFound($"No se encontró ningún usuario con el nombre {nombreSeguido}");
            }
            bool resultado = servicio.SeguirUsuario(nombreSeguidor, nombreSeguido);

            if (!resultado)
            {
                return BadRequest($"{nombreSeguidor} ya sigue a {nombreSeguido}");
            }
            return Ok($"{nombreSeguidor} empezó a seguir a {nombreSeguido}");
        }

        [HttpGet("wall/{nombre}")]
        public IActionResult Dashboard(string nombre)
        {
            var posts = servicio.ObtenerPostsDeSeguidos(nombre);

            return Ok(posts);
        }
    }
}
