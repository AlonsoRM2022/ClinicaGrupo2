using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Doctore
    {
        public Doctore()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdDoctor { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public bool? StatusDoctor { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
