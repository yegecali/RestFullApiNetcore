using Infraestructure.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts() 
        {
            var publicaciones = new PublicacionRepo().GetPublicaciones();
            return Ok(publicaciones);
        }
    }
}
