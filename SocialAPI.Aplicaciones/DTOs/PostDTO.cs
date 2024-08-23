using SocialAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAPI.Aplicaciones.DTOs
{
    public class PostDTO
    {
        public Guid PostId { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
