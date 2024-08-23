using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUser<TEntidad, TEntidadID> : IAgregar<TEntidad>, IActualizar<TEntidad>, IListar<TEntidad, TEntidadID>
    {
        TEntidad ObtenerPorNombre(string nombre);
    }
}
