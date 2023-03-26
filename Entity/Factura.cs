using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    internal class Factura
    {
        public string IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string NIC { get; set; }
        public string NombreCLiente { get; set; }
        public decimal ValorTotal { get; set; }
        public int CantidadTotal { get; set; }
    }
}
