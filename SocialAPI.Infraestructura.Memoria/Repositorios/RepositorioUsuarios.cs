using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialAPI.Dominio;
using SocialAPI.Dominio.Interfaces.Repositorios;
using SocialAPI.Aplicaciones.DTOs;

namespace SocialAPI.Infraestructura.Memoria.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUser<Usuario, Guid>
    {

        private readonly List<Usuario> usuario = new List<Usuario>();

        public RepositorioUsuarios()
        {
            // Crear 3 usuarios por defecto
            usuario.Add(new Usuario("Alfonso") { UsuarioId = Guid.NewGuid() });
            usuario.Add(new Usuario("Alicia") { UsuarioId = Guid.NewGuid() });
            usuario.Add(new Usuario("Iván") { UsuarioId = Guid.NewGuid() });
        }

        public Usuario Agregar(Usuario entidad)
        {
            usuario.Add(entidad);
            return entidad;  // Devuelve la entidad agregada
        }

        public Usuario ObtenerPorNombre(string entidadNombre)
        {
            var nombreObtenido = usuario.FirstOrDefault(u => u.Nombre == entidadNombre);
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
            //if (usuarioSeleccionado == null)
            //{
            //    throw new Exception($"No se encontró un usuario con el ID {entidadID}");
            //}
            return usuarioSeleccionado;
        }
    }
}
