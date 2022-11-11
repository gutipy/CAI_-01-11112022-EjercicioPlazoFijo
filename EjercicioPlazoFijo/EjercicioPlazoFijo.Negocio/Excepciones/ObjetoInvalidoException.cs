using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio.Excepciones
{
    public class ObjetoInvalidoException : Exception
    {
        public ObjetoInvalidoException(string objeto) : base ("El " + objeto + "está vacío, intente nuevamente completando todos los datos requeridos.")
        {

        }
    }
}
