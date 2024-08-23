using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialAPI.Dominio;
using SocialAPI.Dominio.Interfaces.Repositorios;
using SocialAPI.Aplicaciones.Interfaces;
using SocialAPI.Aplicaciones.DTOs;

namespace SocialAPI.Aplicaciones.Servicios
{
    public class UsuarioServicio : IUsuarioService<Usuario, Guid>
    {
        private readonly IRepositorioUser<Usuario, Guid> repoUsuario;

        public UsuarioServicio(IRepositorioUser<Usuario, Guid> _repoUsuario)
        {
            repoUsuario = _repoUsuario;
        }

        public Usuario Agregar(Usuario entidad)
        {
            return repoUsuario.Agregar(entidad);
        }

        public Usuario Actualizar(Usuario entidad)
        {
            return repoUsuario.Actualizar(entidad);
        }

        public List<Usuario> Listar()
        {
            return repoUsuario.Listar();
        }

        public Usuario SelectPorID(Guid entidadID)
        {
            return repoUsuario.SelectPorID(entidadID);
        }

        public void PublicarPost(string usuario, string texto)
        {
            var user = repoUsuario.ObtenerPorNombre(usuario);
            if (user != null)
            {
                user.PublicarPost(texto);
                repoUsuario.Actualizar(user);
            }
        }

        public bool SeguirUsuario(string seguidor, string seguido)
        {
            var userSeguidor = repoUsuario.ObtenerPorNombre(seguidor);
            var userSeguido = repoUsuario.ObtenerPorNombre(seguido);
            if (userSeguido != null && userSeguidor != null)
            {
                if (userSeguidor.Siguiendo.Contains(userSeguido))
                {
                    return false;//Me indica que ya sigue a este usuario
                }

                userSeguidor.SeguirUsuario(userSeguido);
                repoUsuario.Actualizar(userSeguidor);
                return true;//Seguimiento exitoso
            }
            return false;//Por si ocurre un error en los usuarios
        }

        public List<PostDTO> ObtenerPostsDeSeguidos(string usuario)
        {
            var user = repoUsuario.ObtenerPorNombre(usuario);
            var posts = user.Siguiendo.SelectMany(s => s.Posts)
                        .OrderByDescending(p => p.Fecha)
                        .Select(p => new PostDTO { PostId = p.PostId, Texto = p.Texto, Fecha = p.Fecha })
                        .ToList();
            return posts;
        }
    }
}
