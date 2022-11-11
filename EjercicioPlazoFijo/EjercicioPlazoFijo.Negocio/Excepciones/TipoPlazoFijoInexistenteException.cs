using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio.Excepciones
{
    public class TipoPlazoFijoInexistenteException : Exception
    {
        public TipoPlazoFijoInexistenteException() : base ("El Tipo de plazo fijo indicado no corresponde a ningun tipo de plazo fijo válido, intente nuevamente.")
        {

        }
    }
}
