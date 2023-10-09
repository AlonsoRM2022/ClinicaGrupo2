using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Precio
    {
        public Precio()
        {
            Especialidades = new HashSet<Especialidade>();
        }

        public int IdPrecio { get; set; }
        public int? Valor { get; set; }

        public virtual ICollection<Especialidade> Especialidades { get; set; }
    }
}
