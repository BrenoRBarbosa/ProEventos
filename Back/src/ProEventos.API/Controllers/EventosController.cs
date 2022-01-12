using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Appication.Contratos;
using ProEventos.Appication.Dtos;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        
       private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
           _eventoService = eventoService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var eventos = await _eventoService.GetAllEventosAsync(true);
                 if(eventos == null) return NoContent();

                 var eventosRetotno = new List<EventoDto>();

            

                 return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Recuperar Eventos. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           try
           {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
           if(evento == null) return NoContent();

           return Ok(evento);
           }
           catch (Exception ex)
           {
               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Recuperar Evento. Error: {ex.Message}");
           }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
           try
           {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
           if(evento == null) return NoContent();

           return Ok(evento);
           }
           catch (Exception ex)
           {
               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Recuperar Evento. Error: {ex.Message}");
           }
        }

        [HttpPost]
        public async Task<IActionResult> post(EventoDto model)
        {
            try
            {
                 var evento = await _eventoService.AddEventos(model);
            if(evento == null) return NoContent();

            

            return Ok(evento);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Salvar Evento. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)
        {
            try
            {
                 var evento = await _eventoService.UpdateEvento(id, model);
                 if(evento == null) return NoContent();

                 return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Atualizar Evento. Error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, EventoDto model)
        {
            try
            {
                if (await _eventoService.DeleteEvento(id))
                    return Ok("Deletado");
                else
                    return BadRequest("Evento Não deletado");
                
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao Tentar Deletar Evento. Error: {ex.Message}");
            }
        }
    }
}
