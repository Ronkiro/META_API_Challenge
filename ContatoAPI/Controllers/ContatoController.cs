using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContatoAPI.Models;
using Microsoft.Extensions.Primitives;
using System.Net.Http;

namespace ContatoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoContext _context;
        private StringValues APIKEY = "TESTAPI";

        public ContatoController(ContatoContext context)
        {
            _context = context;
        }

        // GET: /Contato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContatos(int page=0, int size=10)
        {
            bool HasAuth = Request.Headers.TryGetValue("Authorization", out APIKEY);
            
            if(!HasAuth){
                return Unauthorized("Não autorizado.");
            }

            var ContatoList = await _context.Contatos.ToListAsync();
            var Result = ContatoList.Skip((page - 1) * size)
                                    .Take(size).ToList();
            if(Result.Count > 0)
            {
                return Ok(Result);
            } 
            else {
                return NotFound("Não foram encontrados registros de contato.");
            }         
        }

        // GET: /Contato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContato(string id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            bool HasAuth = Request.Headers.TryGetValue("Authorization", out APIKEY);
            
            if(!HasAuth){
                return Unauthorized("Não autorizado.");
            }

            if (contato == null)
            {
                return NotFound("Contato não encontrado.");
            }

            return Ok(contato);
        }

        // PUT: /Contato/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContato(string id, [FromBody] Contato contato)
        {
            bool HasAuth = Request.Headers.TryGetValue("Authorization", out APIKEY);
            
            if(!HasAuth){
                return Unauthorized("Não autorizado.");
            }

            var oldContato = await _context.Contatos.FindAsync(id);
            if(oldContato == null)
            {
                return NotFound("Contato não encontrado.");
            }

            contato.IdContato = oldContato.IdContato;
            oldContato.Canal = contato.Canal;
            oldContato.Nome = contato.Nome;
            oldContato.Obs = contato.Obs;
            oldContato.Valor = contato.Valor;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
                {
                    return NotFound("Contato não encontrado.");
                }
                else
                {
                    return BadRequest("Bad Request.");
                }
            }

            return NoContent();
        }

        // POST: /Contato
        [HttpPost]
        public async Task<ActionResult<Contato>> PostContato([FromBody]Contato contato)
        {
            bool HasAuth = Request.Headers.TryGetValue("Authorization", out APIKEY);
            
            if(!HasAuth){
                return Unauthorized("Não autorizado.");
            }

            contato.IdContato = _context.Contatos.Count().ToString();
            try {
                _context.Contatos.Add(contato);
                await _context.SaveChangesAsync();
            } 
            catch (DbUpdateConcurrencyException) {
                return BadRequest("Erro ao criar novo contato.");
            }
            return StatusCode(201, "Contato criado com sucesso.");
        }

        // DELETE: /Contato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> DeleteContato(string id)
        {
            bool HasAuth = Request.Headers.TryGetValue("Authorization", out APIKEY);
            
            if(!HasAuth){
                return Unauthorized("Não autorizado.");
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound("Contato não encontrado.");
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatoExists(string id)
        {
            return _context.Contatos.Any(e => e.IdContato == id);
        }
    }
}
