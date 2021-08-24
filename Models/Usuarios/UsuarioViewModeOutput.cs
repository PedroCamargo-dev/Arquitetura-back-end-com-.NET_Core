using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{
    public class UsuarioViewModeOutput
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
