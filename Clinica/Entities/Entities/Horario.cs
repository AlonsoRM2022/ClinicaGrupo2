using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Horario
    {
        public Horario()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdHorario { get; set; }
        public string? Dia { get; set; }
        public string? Hora { get; set; }
        public bool? StatusHorario { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
