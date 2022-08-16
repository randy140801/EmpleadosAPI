using System;
using System.Collections.Generic;

namespace EmpleadosApi.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Cargo { get; set; } = null!;
    }
}
