using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAPI.Dominio
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Usuario> Siguiendo { get; set; } = new List<Usuario>();

        public Usuario(string nombre)
        {
            UsuarioId = Guid.NewGuid();
            Nombre = nombre;
        }

        public void PublicarPost(string texto)
        {
            Posts.Add(new Post(texto));
        }

        public void SeguirUsuario(Usuario usuario)
        {
            if (!Siguiendo.Contains(usuario))
            {
                Siguiendo.Add(usuario);
            }
        }
    }
}
