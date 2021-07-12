using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repos
{
    public class PublicacionRepo : IPublicacionRepo
    {
        private readonly SocialMediaContext _context;
        public PublicacionRepo(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Publicacion>> GetPublicaciones()
        {
            var publicaciones = await _context.Publicacions.ToListAsync();            
            return publicaciones;
        }
        public async Task<Publicacion> GetPublicacion(int id) 
        {
            var publicacion = await _context.Publicacions.FirstOrDefaultAsync(x=> x.IdPublicacion == id);
            return publicacion;
        }
        public async Task InsertPublicacion(Publicacion pub)
        {
            _context.Publicacions.Add(pub);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdatePublicacion(Publicacion publicacion) 
        {
            var currentPublicacion = await GetPublicacion(publicacion.IdPublicacion);
            currentPublicacion.Fecha = publicacion.Fecha;
            currentPublicacion.Descripcion = publicacion.Descripcion;
            currentPublicacion.Imagen = publicacion.Imagen;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;        
        }
        public async Task<bool> DeletePublicacion(int id)
        {
            var currentPublicacion = await GetPublicacion(id);
            _context.Publicacions.Remove(currentPublicacion);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
    }
}
