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
    public class DetallesFacturaController : ControllerBase
    {
        private readonly WigaPruebaTecnicaDBContext _context;

        private readonly IMapper _mapper;


        public DetallesFacturaController(WigaPruebaTecnicaDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DetallesFactura
        [HttpGet]
        public IEnumerable<DetalleFacturaDTO> GetDetalleFactura()
        {
            return _mapper.Map<IEnumerable<DetalleFacturaDTO>>(_context.DetalleFacturas);
        }
        //public async Task<ActionResult<IEnumerable<DetalleFactura>>> GetDetalleFacturas()
        //{
        //    return await _context.DetalleFacturas.ToListAsync();
        //}

        // GET: api/DetallesFactura/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallesById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle = _context.DetalleFacturas.Where(m => m.NumeroFactura == Id);

            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DetalleFacturaDTO>>(detalle));
        }
        //public async Task<ActionResult<DetalleFactura>> GetDetalleFactura(int id)
        //{
        //    var detalleFactura = await _context.DetalleFacturas.FindAsync(id);

        //    if (detalleFactura == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<DetalleFacturaDTO>(detalleFactura));

        //}

        // PUT: api/DetallesFactura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFactura(int id, DetalleFactura detalleFactura)
        {
            detalleFactura.IdProductoNavigation = null;
            detalleFactura.NumeroFacturaNavigation = null;

            if (id != detalleFactura.NumDetalle)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.Map<DetalleFacturaDTO>(detalleFactura)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturaExists(id))
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

        // POST: api/DetallesFactura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalleFactura>> PostDetalleFactura(DetalleFactura detalleFactura)
        {
            detalleFactura.IdProductoNavigation = null;
            detalleFactura.NumeroFacturaNavigation = null;

            var map = _mapper.Map<DetalleFactura>(detalleFactura);
            _context.DetalleFacturas.Add(map);
            await _context.SaveChangesAsync();
            detalleFactura.NumDetalle = map.NumDetalle;

            return CreatedAtAction("GetDetalleFactura", new { id = map.NumDetalle }, detalleFactura);
        }

        // DELETE: api/DetallesFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFactura>> DeleteDetalleFactura(int id)
        {
            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            _context.DetalleFacturas.Remove(detalleFactura);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<DetalleFacturaDTO>(detalleFactura));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFacturas.Any(e => e.NumDetalle == id);
        }
    }
}
