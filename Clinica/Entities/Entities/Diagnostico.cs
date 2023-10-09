using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public string? Descripcion { get; set; }
        public int? IdReserva { get; set; }

        public virtual Reserva? IdReservaNavigation { get; set; }
    }
}
