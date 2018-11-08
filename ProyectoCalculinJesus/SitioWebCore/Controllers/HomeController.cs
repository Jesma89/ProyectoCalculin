using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SitioWebCore.Models;
using Modelo;
using Repositorio;
using SitioWebCore.ViewModels;
using ForexQuotes;
using Microsoft.AspNetCore.Authorization;

namespace SitioWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio _repositorio;

        public HomeController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        [Authorize]
        [HttpGet]
        public IActionResult VerMonedas()
        {
            var listaMonedas = _repositorio.ObtenerMonedas();

            var homeViewModel = new HomeViewModel
            {
                Titulo = "Calculin",
                ListaMonedas = listaMonedas,
                ImagenMoneda = "https://www.worldatlas.com/r/w728-h425-c728x425/upload/d0/91/86/shutterstock-403371907.jpg"
            };

            return View(homeViewModel);
        }


        public IActionResult DetalleMoneda(int id)
        {
            var moneda = _repositorio.BuscarMonedaPorId(id);
            if (moneda == null)
                return NotFound();

            return View(moneda);
        }
        
        [HttpGet]
        public IActionResult ActualizarMonedas()
        {
            var client =
            new ForexDataClient("i3drSZDmC8Kis9rruVPtCciybrr3ut3s");

            var symbols = client.GetSymbols();
            var quotes = client.GetQuotes(symbols);
            foreach (var symbol in symbols)
            {

               var abreviatura = symbol.Substring(0, 3);
                _repositorio.CrearMoneda(new Moneda { Abreviatura = abreviatura });

            }
            foreach (var quote in quotes)
            {

                var monedaOrigen = quote.symbol.Substring(0, 3);
                var monedaDestino = quote.symbol.Substring(3, 3);
                _repositorio.CrearFactor(new FactorConversion {
                    IdMonedaOrigen = _repositorio.BuscarMonedaPorNombre(monedaOrigen),
                    IdMonedaDestino = _repositorio.BuscarMonedaPorNombre(monedaDestino),
                    Factor = (decimal)quote.price
                });

            }

            ViewBag.NumeroMonedas = symbols.Length;
            return View();
        }



        [HttpPost]
        public IActionResult DetalleMoneda(Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                _repositorio.ActualizarMoneda(moneda);
                return RedirectToAction("Index");
            }
            return View(moneda);
        }
        private void UpdateQuote(Quote quote)
        {
            var left = quote.symbol.Substring(0, 3);
            var right = quote.symbol.Substring(3, 3);

        }

        public IActionResult Index()
        {


            //ActualizarMonedas();


            return View();
        }

        private void Extraer(string symbol, int pos)
        {
            var left = symbol.Substring(0, 3);
            var moneda = new Moneda { Abreviatura = left, Nombre = left };
            _repositorio.CrearMoneda(moneda);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize]
        public IActionResult CalcularMoneda(HomeViewModel model)
        {
            var resultado = model.Cantidad;
            var idOrigen = _repositorio.BuscarMonedaPorNombre(model.IdOrigen);
            var idDestino = _repositorio.BuscarMonedaPorNombre(model.IdDestino);
            var idFactor = _repositorio.BuscarFactorPorMonedas(idOrigen, idDestino);
            var factor = _repositorio.BuscarFactoresPorId(idFactor);
            if (factor != null)
            {
                resultado = model.Cantidad * factor.Factor;
            }
            var conversor = new ConversorViewModel
            {
                IdOrigen = model.IdOrigen,
                IdDestino = model.IdDestino,
                Cantidad = model.Cantidad,
                Resultado = resultado,
                Precio= factor.Factor
   
            };
            return View(conversor);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
