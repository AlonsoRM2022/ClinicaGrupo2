using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class StatusReserva
    {
        public StatusReserva()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdStatusReserva { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
