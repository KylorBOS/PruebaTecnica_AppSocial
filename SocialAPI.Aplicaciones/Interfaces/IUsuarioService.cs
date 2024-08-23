using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialAPI.Aplicaciones.DTOs;
using SocialAPI.Dominio.Interfaces;

namespace SocialAPI.Aplicaciones.Interfaces
{
    public interface IUsuarioService<TEntidad, TEntidadID> : IAgregar<TEntidad>, IActualizar<TEntidad>, IListar<TEntidad, TEntidadID>
    {
        bool SeguirUsuario(string seguidor, string seguido);
        void PublicarPost(string usuario, string texto);

        List<PostDTO> ObtenerPostsDeSeguidos(string usuario);
    }
}
