using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Contexto;
using Modelo;
using System.Data.Entity;
using Repositorio;

namespace ServicioMonedas
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioMoneda : IServicioMoneda
    {
         readonly MonedaDb Context = new MonedaDb();
        Repo repo = new Repo();
        public void CrearMoneda(Moneda moneda)
        {
            repo.CrearMoneda(moneda);  
        }
        public List<Moneda> ObtenerMonedas()
        {
            return repo.ObtenerMonedas();
        }
        public Moneda BuscarMonedaPorAbreviatura(string abreviatura)
        {
            return repo.BuscarMonedaPorAbreviatura(abreviatura);
        }
        public Moneda BuscarMonedaPorNombre(string nombre)
        {
            return repo.BuscarMonedaPorNombre(nombre);
        }
        public void ActualizarMoneda(Moneda moneda1, Moneda moneda2)
        {
             repo.ActualizarMoneda(moneda1, moneda2);
        }
        public void BorrarMoneda(Moneda moneda)
        {
            repo.BorrarMoneda(moneda);
        }
     
        public void Dispose()
        {
           Context.Dispose();
        }

    
    }
}
