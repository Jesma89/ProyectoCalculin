using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Modelo;

namespace Infraestructura
{
    public class Seed
    {
        public static List<Moneda> CrearListaMonedas()
        {

            var monedas = ProcesarArchivo("Monedas.csv");

            List<Moneda> listaMonedas = new List<Moneda>{
                new Moneda{Abreviatura = "EUR"},
                new Moneda{Abreviatura = "GBP"},
                new Moneda{Abreviatura = "USD"},
                new Moneda{Abreviatura = "INR"},
                new Moneda{Abreviatura = "AUD"}
            };
            return listaMonedas;

        }

        private static List<Moneda> ProcesarArchivo(string monedasCsv)
        {
            var query =

                File.ReadAllLines(monedasCsv)
                    .Skip(1)
                    .Where(l => l.Length > 1);
            //.ToCar();

            //return query.ToList();
            return null;
        }

        public static List<ConversionFactor>
            CrearListaFactores()
        {
            var listaMonedasOrigen = CrearListaMonedas();
            var listaMonedasDestino = CrearListaMonedas();
            var listaFactores = new List<ConversionFactor>();

            foreach (var monedaOrigen in listaMonedasOrigen)
            {
                foreach (var monedaDestino in listaMonedasDestino)
                {
                    if (monedaOrigen.Abreviatura == monedaDestino.Abreviatura)
                    {
                        continue;
                    }

                    var factor = new ConversionFactor(monedaOrigen.Id, monedaDestino.Id, ObtenerAleatorio());
                    listaFactores.Add(factor);
                }

            }


            return null;
        }

        public static int ObtenerAleatorio()
        {
            int randomvalue;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomvalue = BitConverter.ToInt32(rno, 0);
            }

            return randomvalue;

        }
    }
}