using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Publicacion
    {
        public int PublicacionId { get; set; }
        public int UserId { get; set; }
        public DateTime Date{ get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
