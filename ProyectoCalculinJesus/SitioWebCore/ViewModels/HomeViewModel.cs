using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWebCore.ViewModels
{
    public class HomeViewModel
    {
        public List<Moneda> ListaMonedas { get; set; }

        public string Titulo { get; set; }

        public string ImagenMoneda { get; set; }

        public string IdOrigen { get; set; }

        public string IdDestino { get; set; }

        public decimal Cantidad { get; set; }

        

        public string ConversorMoneda { get; set; }
    }
}
