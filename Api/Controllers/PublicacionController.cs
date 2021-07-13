using Api.Responses;
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
        private readonly IPublicacionService _publicacionService;
        private readonly IMapper _mapper;
        public PublicacionController(IPublicacionService publicacionService, IMapper mapper)
        {
            _publicacionService = publicacionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPublicaciones() 
        {
            var publicaciones = await _publicacionService.getPublicaciones();
            var publicacionesDto = _mapper.Map<IEnumerable<PublicacionDto>>(publicaciones);
            //var response = new ApiResponse<IEnumerable<PublicacionDto>>(publicacionesDto);
            return Ok(publicacionesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicacion(int id)
        {
            var publicacion = await _publicacionService.getPublicacion(id);
            var publicacionDto = _mapper.Map<PublicacionDto>(publicacion);
            var response = new ApiResponse<PublicacionDto>(publicacionDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePublicacion(PublicacionDto publi)
        {
            var publicacion = _mapper.Map<Publicacion>(publi);
            await _publicacionService.InsertarPublicacion(publicacion);
            var publicacionDto = _mapper.Map<PublicacionDto>(publicacion);
            var response = new ApiResponse<PublicacionDto>(publicacionDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarPublicacion(int id,  PublicacionDto publi)
        {
            var publicacion = _mapper.Map<Publicacion>(publi);
            publi.IdPublicacion = id;
            var result = await _publicacionService.UpdatePublicacion(publicacion);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPublicacion(int id) 
        {
            var result = await _publicacionService.DeletePublicacion(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
 