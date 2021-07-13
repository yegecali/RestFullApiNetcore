using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IRepository<Publicacion> _PublicacionRepo;
        private readonly IRepository<Usuario> _UsuarioRepo;
        private readonly IRepository<Comentario> _ComentarioRepo;
        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }
        public IRepository<Publicacion> PublicacionRepo => _PublicacionRepo ?? new Repository<Publicacion>(_context);
        public IRepository<Usuario> UsuarioRepo => _UsuarioRepo ?? new Repository<Usuario>(_context);
        public IRepository<Comentario> ComentarioRepo => _ComentarioRepo ?? new Repository<Comentario>(_context);

        public void Dispose()
        {
            if (_context == null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
