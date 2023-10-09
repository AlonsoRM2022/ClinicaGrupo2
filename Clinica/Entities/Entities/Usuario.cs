using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Contraseña { get; set; }
        public bool? StatusUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdRol { get; set; }

        public virtual Role? IdRolNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
