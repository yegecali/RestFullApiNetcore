using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable 
    {
        IRepository<Publicacion> PublicacionRepo { get; }
        IRepository<Usuario> UsuarioRepo { get; }
        IRepository<Comentario> ComentarioRepo{ get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
