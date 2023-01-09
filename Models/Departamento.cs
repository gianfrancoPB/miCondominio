using System;
using System.Collections.Generic;

namespace miCondominio.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Personas = new HashSet<Persona>();
        }

        public int IdDepartamento { get; set; }
        public int? NumeroPiso { get; set; }
        public int? NumeroDep { get; set; }
        public int? CantidadCuartos { get; set; }
        public int? CantidadBaños { get; set; }
        public bool? BAmoblado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
