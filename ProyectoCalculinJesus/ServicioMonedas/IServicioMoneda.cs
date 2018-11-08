using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;


namespace ServicioMonedas
{
    [ServiceContract]
    
    public interface IServicioMoneda
    {

       [OperationContract]
        void CrearMoneda(Moneda moneda);
         [OperationContract]
        List<Moneda> ObtenerMonedas();
         [OperationContract]
        Moneda BuscarMonedaPorAbreviatura(string abreviatura);
         [OperationContract]
        Moneda BuscarMonedaPorNombre(string nombre);
        [OperationContract]
        void ActualizarMoneda(Moneda moneda1, Moneda moneda2);
        [OperationContract]
        void BorrarMoneda(Moneda moneda);
        
     



    }
   
  
}
