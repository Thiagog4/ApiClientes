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
    public class DadosClientes1Controller : ControllerBase
    {
        private readonly ApiClientesContext _context;

        public DadosClientes1Controller(ApiClientesContext context)
        {
            _context = context;
        }

        // GET: api/DadosClientes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosClientes>>> GetDadosClientes()
        {
          if (_context.DadosClientes == null)
          {
              return NotFound();
          }
            return await _context.DadosClientes.ToListAsync();
        }

        // GET: api/DadosClientes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DadosClientes>> GetDadosClientes(int id)
        {
          if (_context.DadosClientes == null)
          {
              return NotFound();
          }
            var dadosClientes = await _context.DadosClientes.FindAsync(id);

            if (dadosClientes == null)
            {
                return NotFound();
            }

            return dadosClientes;
        }

        // PUT: api/DadosClientes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDadosClientes(int id, DadosClientes dadosClientes)
        {
            if (id != dadosClientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(dadosClientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosClientesExists(id))
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

        // POST: api/DadosClientes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DadosClientes>> PostDadosClientes(DadosClientes dadosClientes)
        {
          if (_context.DadosClientes == null)
          {
              return Problem("Entity set 'ApiClientesContext.DadosClientes'  is null.");
          }
            _context.DadosClientes.Add(dadosClientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDadosClientes", new { id = dadosClientes.Id }, dadosClientes);
        }

        // DELETE: api/DadosClientes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDadosClientes(int id)
        {
            if (_context.DadosClientes == null)
            {
                return NotFound();
            }
            var dadosClientes = await _context.DadosClientes.FindAsync(id);
            if (dadosClientes == null)
            {
                return NotFound();
            }

            _context.DadosClientes.Remove(dadosClientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DadosClientesExists(int id)
        {
            return (_context.DadosClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
