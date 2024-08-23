using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAPI.Dominio
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Post(string texto)
        {
            PostId = Guid.NewGuid();
            Texto = texto;
            Fecha = DateTime.Now;
        }
    }
}
