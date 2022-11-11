using EjercicioPlazoFijo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio
{
    public static class TipoPlazoFijoFactory
    {
        private static List<TipoPlazoFijo> _tipos;

        static TipoPlazoFijoFactory()
        {
            _tipos = new List<TipoPlazoFijo>();
            _tipos.Add(new TipoPlazoFijo(1, 40, "Plazo Fijo Web"));
            _tipos.Add(new TipoPlazoFijo(2, 3, "Plazo Fijo UVA"));


        }

        public static List<TipoPlazoFijo> Get()
        {
            return _tipos;
        }

        public static TipoPlazoFijo Get(int id)
        {
            return _tipos.SingleOrDefault(x => x.Id == id);
        }


    }
}

