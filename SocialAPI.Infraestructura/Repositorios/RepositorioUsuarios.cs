using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialAPI.Dominio;
using SocialAPI.Dominio.Interfaces.Repositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialAPI.Infraestructura.Memoria.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUser<Usuario, Guid>
    {
        private readonly List<Usuario> usuario = new List<Usuario>();

        public Usuario Agregar(Usuario entidad)
        {
            usuario.Add(entidad);
            return entidad;  // Devuelve la entidad agregada
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            var nombreObtenido = usuario.FirstOrDefault(u => u.Nombre == nombre);
            return nombreObtenido;
        }

        public Usuario Actualizar(Usuario entidad)
        {
            var usuarioExistente = usuario.FirstOrDefault(u => u.UsuarioId == entidad.UsuarioId);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = entidad.Nombre;
            }
            return usuarioExistente;  // Devuelve el usuario actualizado
        }

        public List<Usuario> Listar()
        {
            return usuario.ToList();
        }

        public Usuario SelectPorID(Guid entidadID)
        {
            var usuarioSeleccionado = usuario.FirstOrDefault(u => u.UsuarioId == entidadID);
            return usuarioSeleccionado;
        }
    }
}
