using System;
using System.Collections.Generic;

#nullable disable

namespace apiWigaPrueba.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
