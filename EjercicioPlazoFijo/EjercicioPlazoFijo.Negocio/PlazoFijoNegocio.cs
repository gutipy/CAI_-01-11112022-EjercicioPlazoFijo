using EjercicioPlazoFijo.Entidades;
using EjercicioPlazoFijo.Datos;
using EjercicioPlazoFijo.Negocio.Excepciones;
using EjercicioPlazoFijo.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Negocio
{
    public class PlazoFijoNegocio
    {
        //Atributos
        private PlazoFijoMapper _plazoFijoMapper;

        //Constructores
        public PlazoFijoNegocio()
        {
            _plazoFijoMapper = new PlazoFijoMapper();
        }

        //Funciones-Métodos
        public List<PlazoFijo> GetLista(string registro)
        {
            //Declaración de variables
            List<PlazoFijo> _totalPlazosFijos = new List<PlazoFijo>();

            _totalPlazosFijos = _plazoFijoMapper.Get(registro); //Guardo en la lista '_totalPlazosFijos' los datos de todos los plazos fijos por nro de registro que me trae la capa de Acceso a datos


            foreach (PlazoFijo pf in _totalPlazosFijos)
            {
                pf.TipoPlazoFijo = TipoPlazoFijoFactory.Get(pf.Tipo);
            }

            return _totalPlazosFijos; //Devuelvo la lista con todos los plazos fijos por nro de registro a la capa de presentación
        }

        public void AgregarPlazoFijo(PlazoFijo nuevoPlazoFijo)
        {
            //Declaración de variables
            List<PlazoFijo> _totalPlazosFijos = new List<PlazoFijo>();
            int maxCapitalInicial = 1000000;

            _totalPlazosFijos = _plazoFijoMapper.Get(nuevoPlazoFijo.Usuario); //Guardo en la lista '_totalPlazosFijos' los datos de todos los plazos fijos por nro de registro que me trae la capa de Datos

            if (nuevoPlazoFijo == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoInvalidoException("Plazo Fijo");
            }

            else if (nuevoPlazoFijo.CapitalInicial > maxCapitalInicial) //Regla de negocio que implica que si un plazo fijo posee más de ARS $1.000.000 de Capital Inicial entonces le muestro una excepcion al user
            {
                throw new MaximoCapitalInicialException(maxCapitalInicial);
            }

            else if (TipoPlazoFijoFactory.Get(nuevoPlazoFijo.Tipo) == null)
            {
                throw new TipoPlazoFijoInexistenteException();
            }

            else if (nuevoPlazoFijo.Tipo == 1 && (nuevoPlazoFijo.Dias < 30 || nuevoPlazoFijo.Dias > 360))
            {
                throw new PlazoErroneoException();
            }

            else if (nuevoPlazoFijo.Tipo == 2 && nuevoPlazoFijo.Dias < 180 || nuevoPlazoFijo.Dias > 270)
            {
                throw new PlazoErroneoException();
            }

            else
            {
                TransactionResult transaction = _plazoFijoMapper.Insert(nuevoPlazoFijo); //Agrego el plazo fijo al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }
    }
}
