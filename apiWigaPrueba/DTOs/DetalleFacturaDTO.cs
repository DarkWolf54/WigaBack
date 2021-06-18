using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiWigaPrueba.DTOs
{
    public class DetalleFacturaDTO
    {
        public int NumDetalle { get; set; }
        public int Cantidad { get; set; }
        public int NumeroFactura { get; set; }
        public int IdProducto { get; set; }

        public FacturaDTO Factura { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}
