using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio.Excepciones
{
    public class MaximoCapitalInicialException : Exception
    {
        public MaximoCapitalInicialException(int montoMaximo) : base ("ERROR! El Capital inicial no puede superar el límite de " + montoMaximo)
        {

        }
    }
}
