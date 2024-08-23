using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAPI.Dominio.Interfaces
{
    public interface IActualizar<TEntidad>
    {
        TEntidad Actualizar(TEntidad entidad);
    }
}
