using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiWigaPrueba.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<FacturaDTO> Facturas { get; set; }
    }
}
