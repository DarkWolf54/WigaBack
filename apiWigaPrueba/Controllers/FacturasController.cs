using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiWigaPrueba.Models;
using AutoMapper;
using apiWigaPrueba.DTOs;

namespace apiWigaPrueba.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly WigaPruebaTecnicaDBContext _context;

        private readonly IMapper _mapper;

        public FacturasController(WigaPruebaTecnicaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Facturas
        [HttpGet]
        public IEnumerable<FacturaDTO> GetFactura()
        {
            return _mapper.Map<IEnumerable<FacturaDTO>>(_context.Facturas);
        }
        //public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        //{
        //    return await _context.Facturas.ToListAsync();
        //}

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturasById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factura = _context.Facturas.Where(m => m.IdCliente == Id);

            if (factura == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<FacturaDTO>>(factura));
        }
        //public async Task<ActionResult<Factura>> GetFactura(int id)
        //{
        //    var factura = await _context.Facturas.FindAsync(id);

        //    if (factura == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<FacturaDTO>(factura));
        //}

        // PUT: api/Facturas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            factura.IdClienteNavigation = null;

            if (id != factura.Numero)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.Map<FacturaDTO>(factura)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            factura.IdClienteNavigation = null;

            var map = _mapper.Map<Factura>(factura);
            _context.Facturas.Add(map);
            await _context.SaveChangesAsync();
            factura.Numero = map.Numero;

            return CreatedAtAction("GetFactura", new { id = map.Numero }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> DeleteFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<FacturaDTO>(factura));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.Numero == id);
        }
    }
}
