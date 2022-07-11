using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClientes.Data;
using ApiClientes.Models;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ClientesContext _context;

        public ContatosController(ClientesContext context)
        {
            _context = context;
        }

        // GET: api/Contatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contatos>>> GetContatos()
        {
          if (_context.Contatos == null)
          {
              return NotFound();
          }
            return await _context.Contatos.ToListAsync();
        }

        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contatos>> GetContatos(int id)
        {
          if (_context.Contatos == null)
          {
              return NotFound();
          }
            var contatos = await _context.Contatos.FindAsync(id);

            if (contatos == null)
            {
                return NotFound();
            }

            return contatos;
        }

        // PUT: api/Contatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatos(int id, Contatos contatos)
        {
            if (id != contatos.Id)
            {
                return BadRequest();
            }

            _context.Entry(contatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contatos>> PostContatos(Contatos contatos)
        {
          if (_context.Contatos == null)
          {
              return Problem("Entity set 'ClientesContext.Contatos'  is null.");
          }
            _context.Contatos.Add(contatos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContatosExists(contatos.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContatos", new { id = contatos.Id }, contatos);
        }

        // DELETE: api/Contatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatos(int id)
        {
            if (_context.Contatos == null)
            {
                return NotFound();
            }
            var contatos = await _context.Contatos.FindAsync(id);
            if (contatos == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatosExists(int id)
        {
            return (_context.Contatos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
