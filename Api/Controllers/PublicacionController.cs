using Core.Interfaces;
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
        private readonly IPublicacionRepo _publicacionRepo;
        public PublicacionController(IPublicacionRepo publicacionRepo)
        {
            _publicacionRepo = publicacionRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            var publicaciones = await _publicacionRepo.GetPublicaciones();
            return Ok(publicaciones);
        }
    }
}
 