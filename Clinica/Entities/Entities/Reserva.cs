using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Reserva
    {
        public Reserva()
        {
            Diagnosticos = new HashSet<Diagnostico>();
            Facturas = new HashSet<Factura>();
        }

        public int IdReserva { get; set; }
        public int? IdCita { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdStatusReserva { get; set; }
        public int? Precio { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Cita? IdCitaNavigation { get; set; }
        public virtual StatusReserva? IdStatusReservaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
