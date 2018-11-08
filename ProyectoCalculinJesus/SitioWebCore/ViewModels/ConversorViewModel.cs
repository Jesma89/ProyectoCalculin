using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWebCore.ViewModels
{
    public class ConversorViewModel
    {

        public string IdOrigen { get; set; }

        public string IdDestino { get; set; }
        public decimal Precio { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Resultado { get; set; }
    }
}
