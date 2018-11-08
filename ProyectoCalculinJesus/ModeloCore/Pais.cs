using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }


        // Propiedades de navegación
     //   public List<Usuario> Usuarios { get; set; }
    }
}
