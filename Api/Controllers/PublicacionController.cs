using AutoMapper;
using Core.DTOs;
using Core.Entities;
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
        private readonly IMapper _mapper;
        public PublicacionController(IPublicacionRepo publicacionRepo, IMapper mapper)
        {
            _publicacionRepo = publicacionRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPublicaciones() 
        {
            var publicaciones = await _publicacionRepo.GetPublicaciones();
            var publicacionesDto = _mapper.Map<IEnumerable<PublicacionDto>>(publicaciones);
            return Ok(publicacionesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacion(int id)
        {
            var publicacion = await _publicacionRepo.GetPublicacion(id);
            var publicacionDto = _mapper.Map<PublicacionDto>(publicacion);
            return Ok(publicacionDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePublicacion(PublicacionDto publi)
        {
            var publicacion = _mapper.Map<Publicacion>(publi);
            await _publicacionRepo.InsertPublicacion(publicacion);
            return Ok(publi);
        }
    }
}
 