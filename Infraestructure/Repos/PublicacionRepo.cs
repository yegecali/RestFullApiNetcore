using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repos
{
    public class PublicacionRepo
    {
        public IEnumerable<Publicacion> GetPublicaciones()
        {
            var publicaciones = Enumerable.Range(1,10).Select(x => new Publicacion
            {
                PublicacionId = x,
                Description = $"Descripcion {x}",
                Date = DateTime.Now,
                Image = $"http://algo.com{x}",
                UserId = x * 2
            } );
            return publicaciones;
        }
    }
}
