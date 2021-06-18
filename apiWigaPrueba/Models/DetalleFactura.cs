using System;
using System.Collections.Generic;

#nullable disable

namespace apiWigaPrueba.Models
{
    public partial class DetalleFactura
    {
        public int NumDetalle { get; set; }
        public int Cantidad { get; set; }
        public int NumeroFactura { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Factura NumeroFacturaNavigation { get; set; }
    }
}
