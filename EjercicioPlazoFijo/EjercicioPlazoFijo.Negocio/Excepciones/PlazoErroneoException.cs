using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio.Excepciones
{
    public class PlazoErroneoException : Exception
    {
        public PlazoErroneoException() : base ("ERROR! El plazo fijo de tipo Web debe tener un plazo de entre 30 y 360 días" + Environment.NewLine + "El plazo fijo de tipo UVA debe tener un plazo de entre 180 y 270 días")
        {

        }
    }
}
