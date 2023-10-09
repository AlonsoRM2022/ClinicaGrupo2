using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? Total { get; set; }
        public int? IdReserva { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Reserva? IdReservaNavigation { get; set; }
    }
}
