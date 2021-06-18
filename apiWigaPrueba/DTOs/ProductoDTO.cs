using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiWigaPrueba.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public List<DetalleFacturaDTO> Detalles { get; set; }
    }
}
