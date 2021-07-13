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
        private readonly IUnitOfWork _unitOfWork;

        public PublicacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeletePublicacion(int id)
        {
            await _unitOfWork.PublicacionRepo.Delete(id);
            return true;
        }

        public async Task<Publicacion> getPublicacion(int id)
        {
            return await _unitOfWork.PublicacionRepo.GetById(id);
        }

        public async Task<IEnumerable<Publicacion>> getPublicaciones()
        {
            return await _unitOfWork.PublicacionRepo.GetAll();
        }

        public async Task InsertarPublicacion(Publicacion publicacion)
        {
            var user = await _unitOfWork.UsuarioRepo.GetById(publicacion.IdUsuario);
            if (user == null) 
            {
                throw new Exception("Usuario no existe");
            }
            if (publicacion.Descripcion.Contains("sexo"))
            {
                throw new Exception("Contenido no permitido");
            }
            await _unitOfWork.PublicacionRepo.Add(publicacion);
        }

        public async Task<bool> UpdatePublicacion(Publicacion publicacion)
        {
            await _unitOfWork.PublicacionRepo.Update(publicacion);
            return true; 
        }
    }
}
