using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeprestpApi.Data;
using TeprestpApi.Models;

namespace TeprestpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupacionesController : ControllerBase
    {
        private readonly Contexto _context;

        public OcupacionesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Ocupaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocupaciones>>> Getocupaciones()
        {
          if (_context.ocupaciones == null)
          {
              return NotFound();
          }
            return await _context.ocupaciones.ToListAsync();
        }

        // GET: api/Ocupaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocupaciones>> GetOcupaciones(int id)
        {
          if (_context.ocupaciones == null)
          {
              return NotFound();
          }
            var ocupaciones = await _context.ocupaciones.FindAsync(id);

            if (ocupaciones == null)
            {
                return NotFound();
            }

            return ocupaciones;
        }

        // PUT: api/Ocupaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcupaciones(int id, Ocupaciones ocupaciones)
        {
            if (id != ocupaciones.OcupacionId)
            {
                return BadRequest();
            }

            _context.Entry(ocupaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcupacionesExists(id))
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

        // POST: api/Ocupaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ocupaciones>> PostOcupaciones(Ocupaciones ocupaciones)
        {
          if (_context.ocupaciones == null)
          {
              return Problem("Entity set 'Contexto.ocupaciones'  is null.");
          }
            _context.ocupaciones.Add(ocupaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcupaciones", new { id = ocupaciones.OcupacionId }, ocupaciones);
        }

        // DELETE: api/Ocupaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcupaciones(int id)
        {
            if (_context.ocupaciones == null)
            {
                return NotFound();
            }
            var ocupaciones = await _context.ocupaciones.FindAsync(id);
            if (ocupaciones == null)
            {
                return NotFound();
            }

            _context.ocupaciones.Remove(ocupaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OcupacionesExists(int id)
        {
            return (_context.ocupaciones?.Any(e => e.OcupacionId == id)).GetValueOrDefault();
        }
    }
}
