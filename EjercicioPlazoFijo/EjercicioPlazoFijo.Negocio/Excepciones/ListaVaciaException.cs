using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio.Excepciones
{
    public class ListaVaciaException : Exception
    {
        public ListaVaciaException(string tipoDeLista) : base ("La lista de " + tipoDeLista + " se encuentra vacía, por favor intente nuevamente.")
        {

        }
    }
}
