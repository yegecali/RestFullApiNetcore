using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepo _publicacionRepo;
        private readonly IUserRepo _userRepo;
        public PublicacionService(IPublicacionRepo publicacionRepo, IUserRepo userRepo)
        {
            _publicacionRepo = publicacionRepo;
            _userRepo = userRepo;
        }

        public async Task<bool> DeletePublicacion(int id)
        {
            return await _publicacionRepo.DeletePublicacion(id);
        }

        public async Task<Publicacion> getPublicacion(int id)
        {
            return await _publicacionRepo.GetPublicacion(id);
        }

        public async Task<IEnumerable<Publicacion>> getPublicaciones()
        {
            return await _publicacionRepo.GetPublicaciones();
        }

        public async Task InsertarPublicacion(Publicacion publicacion)
        {
            var user = await _userRepo.GetUsuario(publicacion.IdUsuario);
            if (user == null) 
            {
                throw new Exception("Usuario no existe");
            }
            if (publicacion.Descripcion.Contains("sexo"))
            {
                throw new Exception("Contenido no permitido");
            }
            await _publicacionRepo.InsertPublicacion(publicacion);
        }

        public async Task<bool> UpdatePublicacion(Publicacion publicacion)
        {
            return await _publicacionRepo.UpdatePublicacion(publicacion);
        }
    }
}
