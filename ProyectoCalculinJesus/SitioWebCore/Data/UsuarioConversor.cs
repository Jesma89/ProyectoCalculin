using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWebCore.Data
{
    public class UsuarioConversor :IdentityUser
    {
        public DateTime FechaNacimiento { get; set; }
        public int Pais { get; set; }
    }
}
