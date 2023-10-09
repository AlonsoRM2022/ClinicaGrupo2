using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Clinica
    {
        public Clinica()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdClinica { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
