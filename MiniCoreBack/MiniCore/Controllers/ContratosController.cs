using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Contratos;
using MiniCore.Models.Contratos;
using MiniCore.Models.Clientes;

namespace MiniCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly DbContextCore _context;

        public ContratosController(DbContextCore context)
        {
            _context = context;
        }

        // GET: api/Contratos
        [HttpGet]
        public async Task<IEnumerable<ContratosViewModel>> GetContratos()
        {
            var contrato = await _context.Contratos.Include(client => client.cliente).ToListAsync();
            return contrato.Select(c => new ContratosViewModel
            {
                idContrato = c.idContrato,
                idCliente_FK = c.idCliente_FK,
                NombreContrato = c.NombreContrato,
                Montos= c.Montos,
                Fecha= c.Fecha,
                cliente = new ClientesViewModel
                {
                    NombreCliente = c.cliente.NombreCliente
                },
            });
          /*if (_context.Contratos == null)
          {
              return NotFound();
          }
            return await _context.Contratos.ToListAsync();*/
        }

        // GET: api/Contratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
          if (_context.Contratos == null)
          {
              return NotFound();
          }
            var contrato = await _context.Contratos.FindAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }

        // PUT: api/Contratos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.idContrato)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contratos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
          if (_context.Contratos == null)
          {
              return Problem("Entity set 'DbContextCore.Contratos'  is null.");
          }
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContrato", new { id = contrato.idContrato }, contrato);
        }

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            if (_context.Contratos == null)
            {
                return NotFound();
            }
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoExists(int id)
        {
            return (_context.Contratos?.Any(e => e.idContrato == id)).GetValueOrDefault();
        }
    }
}
