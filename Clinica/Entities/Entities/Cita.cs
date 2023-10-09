using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Cita
    {
        public Cita()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCita { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdEspecialidad { get; set; }
        public int? IdClinica { get; set; }
        public int? IdHorario { get; set; }
        public bool? StatusCita { get; set; }

        public virtual Clinica? IdClinicaNavigation { get; set; }
        public virtual Doctore? IdDoctorNavigation { get; set; }
        public virtual Especialidade? IdEspecialidadNavigation { get; set; }
        public virtual Horario? IdHorarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
