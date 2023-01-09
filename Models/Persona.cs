using System;
using System.Collections.Generic;

namespace miCondominio.Models
{
    public partial class Persona
    {
        public int Dni { get; set; }
        public string Nombres { get; set; } = null!;
        public string? ApellidoPat { get; set; }
        public string? ApellidoMat { get; set; }
        public int? Edad { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamento? IdDepartamentoNavigation { get; set; }
    }
}
