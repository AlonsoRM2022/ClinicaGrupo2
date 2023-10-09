using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdEspecialidad { get; set; }
        public string? Nombre { get; set; }
        public int? IdPrecio { get; set; }
        public bool? StatusEspecialidad { get; set; }

        public virtual Precio? IdPrecioNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
