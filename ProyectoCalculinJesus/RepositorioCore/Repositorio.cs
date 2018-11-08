
using System.Collections.Generic;
using System.Linq;
using Modelo;
using Contexto;
using System;


//CREAR MODELO CRUD PARA TODOS LAS CLASES DE MODELO
namespace Repositorio
{

    public class Repo : IRepositorio
    {
        private readonly MonedaDb _contexto;

        public Repo(MonedaDb contexto)
        {
            _contexto = contexto;
            ListaMonedas = new List<Moneda>();
        }
        public List<Moneda> ListaMonedas { get; set; }
        public List<FactorConversion> ListaFactores { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // C - CREATE
        public void CrearMoneda(Moneda moneda)
        {
            // using (var context = _contexto)
            //{
            var buscarMoneda = BuscarMonedaPorNombre(moneda.Abreviatura);
            if (buscarMoneda == -1)
            {
                _contexto.Monedas.Add(moneda);
                _contexto.SaveChanges();
            }
            else
            {
                moneda.Id = buscarMoneda;
                ActualizarMoneda(moneda);
            }

            // }
        }

        // R - RETRIEVE
        public List<Moneda> ObtenerMonedas()
        {
            //  using (var context = _contexto)
            //{
            return _contexto.Monedas.ToList();
            //}

        }


        public int BuscarMonedaPorNombre(string nombre )
        {   
            //  using (var context = _contexto)
            //{
           var moneda = _contexto.Monedas.FirstOrDefault
            (p => p.Abreviatura == nombre);
            if (moneda == null)
            {
                return -1;
            }
            else
            {
                return moneda.Id;
            }
            //}

        }
        public List<FactorConversion> ObtenerFactores()
        {
            //return Seed.CrearListaFactores();
            //  using (var context = _contexto)
            // {
            return _contexto.ConversionFactores.ToList();
            //}
        }

        public Moneda BuscarMonedaPorId(int IdMoneda)
        {
            return _contexto.Monedas.FirstOrDefault(
                  p => p.Id == IdMoneda);

        }

        // U - UPDATE

        // D - DELETE

        public void BorrarMoneda(int Id)
        {
            //  using (var context = _contexto)
            // {
            var buscarMoneda = BuscarMonedaPorId(Id);
            if (buscarMoneda != null)
            {
                _contexto.Monedas.Remove(buscarMoneda);
                _contexto.SaveChanges();
            }
            // }
        }


        public void ActualizarMoneda(Moneda moneda)
        {
            //  using (var context = _contexto)
            //{
            var buscarMoneda = BuscarMonedaPorId(moneda.Id);
            if (buscarMoneda != null)
            {
                buscarMoneda.Nombre = moneda.Nombre;
                buscarMoneda.Abreviatura = moneda.Abreviatura;
                _contexto.SaveChanges();
            }
            //}
        }

       
        public List<Moneda> GetMonedas()
        {
            throw new NotImplementedException();
        }

        public void ActualizarFactor(FactorConversion factor)
        {
            var factorbuscado=BuscarFactoresPorId(factor.Id);
            factorbuscado.IdMonedaDestino = factor.IdMonedaDestino;
            factorbuscado.IdMonedaOrigen = factor.IdMonedaOrigen;
            factorbuscado.Factor = factor.Factor;
        }

        public void BorrarFactor(FactorConversion factor)
        {
            throw new NotImplementedException();
        }

        public int BuscarFactorPorMonedas(int idOrigen, int idDestino)
        {
          var factor = _contexto.ConversionFactores.FirstOrDefault(p => p.IdMonedaOrigen == idOrigen && p.IdMonedaDestino==idDestino);
            if (factor == null)
            {
                return -1;
            }
            else
            {
               return factor.Id;
            }
        }

        public void CrearFactor(FactorConversion factor)
        {
          var factorbuscado = BuscarFactorPorMonedas(factor.IdMonedaOrigen, factor.IdMonedaDestino);
            if (factorbuscado == -1)
            {
                _contexto.ConversionFactores.Add(factor);
                _contexto.SaveChanges();
            }
            else
            {
                factor.Id = factorbuscado;
                ActualizarFactor(factor);
            }
        }
       
        public List<FactorConversion> GetFactores()
        {
            throw new NotImplementedException();
        }

        public List<FactorConversion> ObtenerFactor()
        {
            throw new NotImplementedException();
        }

        public FactorConversion BuscarFactoresPorId(int Id)
        {
            return _contexto.ConversionFactores.FirstOrDefault(p => p.Id == Id);
        }
    }


    public interface IRepositorio
    {
        List<Moneda> ListaMonedas { get; set; }

        void ActualizarMoneda(Moneda moneda);

        void BorrarMoneda(int Id);
        Moneda BuscarMonedaPorId(int idMoneda);

        void CrearMoneda(Moneda moneda);
        List<Moneda> GetMonedas();

        List<Moneda> ObtenerMonedas();

        int BuscarMonedaPorNombre(string nombre);

    




        List<FactorConversion> ListaFactores { get; set; }

        void ActualizarFactor(FactorConversion factor);

        void BorrarFactor(FactorConversion factor);
        int BuscarFactorPorMonedas(int idOrigen,int idDestino);

        void CrearFactor(FactorConversion factor);
        List<FactorConversion> GetFactores();

        List<FactorConversion> ObtenerFactor();
        FactorConversion BuscarFactoresPorId(int Id);

    }

    //public class RepositorioFalso : IRepositorio
    //{

    //    public void ActualizarMoneda(Moneda moneda)
    //    {
    //    }

    //    public void BorrarMoneda(Moneda moneda)
    //    {
    //    }

    //    public Moneda BuscarMonedaPorId(int IdMoneda)
    //    {
    //        return new Moneda();
    //    }

    //    public void CrearMoneda(Moneda moneda)
    //    {
    //    }

    //    public List<Moneda> GetMonedas()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Moneda> ListaMonedas { get; set; }
    //    public List<FactorConversion> ListaFactores { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public List<Moneda> ObtenerMonedas()
    //    {
    //        var lista = new List<Moneda>
    //        {
    //            new Moneda {Abreviatura = "EUR", Nombre = "Euros"},
    //            new Moneda {Abreviatura = "USD", Nombre = "Dolares"}
    //        };
    //        return lista;
    //    }

    //    public Moneda BuscarMonedaPorNombre(string nombre)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ActualizarFactor(FactorConversion factor)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void BorrarFactor(FactorConversion factor)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public FactorConversion BuscarFactorPorMonedas(int idOrigen, int idDestino)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void CrearFactor(FactorConversion factor)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<FactorConversion> GetFactores()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<FactorConversion> ObtenerFactor()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public FactorConversion BuscarFactoresPorId(int Id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
