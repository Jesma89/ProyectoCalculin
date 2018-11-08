using System;
using Repositorio;

namespace ServicioConversion
{
    public class Conversor
    {
        public IRepositorio repositorio;
        public Conversor (IRepositorio repo)
        {
            repositorio = repo;
        }
    }
}
