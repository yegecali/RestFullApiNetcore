using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPublicacionService
    {
        Task<IEnumerable<Publicacion>> getPublicaciones();
        Task<Publicacion> getPublicacion(int id);
        Task InsertarPublicacion(Publicacion publicacion);
        Task<bool> UpdatePublicacion(Publicacion publicacion);
        Task<bool> DeletePublicacion(int id);
    }
}
