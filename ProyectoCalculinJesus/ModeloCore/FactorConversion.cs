using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    public class FactorConversion
    {
        [Key]
        public int Id { get; set; }
        public decimal Factor { get; set; }
        public int IdMonedaOrigen { get; set; }
        public int IdMonedaDestino { get; set; }

        // Propiedades de Navegacion
       
        //public Moneda MonedaOrigen { get; set; }
        
        //public Moneda MonedaDestino { get; set; }

      
    }
}
