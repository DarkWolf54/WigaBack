using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiWigaPrueba.DTOs
{
    public class FacturaDTO
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }

        public ClienteDTO Cliente { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; }
    }
}
