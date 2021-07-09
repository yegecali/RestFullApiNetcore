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
    }
}
