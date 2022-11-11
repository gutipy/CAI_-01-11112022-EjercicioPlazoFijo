using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using EjercicioPlazoFijo.Entidades;
using EjercicioPlazoFijo.Negocio;

namespace EjercicioPlazoFijo.Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PlazoFijoNegocio plazoFijoServicio = new PlazoFijoNegocio();

                bool consolaActiva = true;

                while (consolaActiva)
                {
                    DesplegarOpcionesMenu();
                    string opcionMenu = Console.ReadLine();
                    switch (opcionMenu)
                    {
                        case "1":
                            ListarPF(plazoFijoServicio);
                            break;
                        case "2":
                            AltaPF(plazoFijoServicio);
                            break;
                        case "3":
                            Reportes(plazoFijoServicio);
                            break;
                        case "X":
                            consolaActiva = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                Console.ReadKey();
            }
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Listar PF");
            Console.WriteLine("2) Alta PF");
            Console.WriteLine("3) Reportes");
            Console.WriteLine("X: Terminar");
        }

        public static void ListarPF(PlazoFijoNegocio plazoFijoNegocio)
        {
            //Declaración de variables
            //---------------------------------------------------
            List<PlazoFijo> _listadoPlazosFijos = new List<PlazoFijo>();
            string _acumulador = "";
            //---------------------------------------------------

            _listadoPlazosFijos = plazoFijoNegocio.GetLista("888086"); //Traigo el listado de plazos fijos de la capa de negocio que a su vez lo trae de la capa de datos

            if (_listadoPlazosFijos.Count == 0 || _listadoPlazosFijos == null) //Valido si la lista de plazos fijos está vacía, caso afirmativo le informo al usuario y le pido que ingrese otra opción
            {
                Console.WriteLine("La lista de plazos fijos está vacía, por favor ingrese otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                foreach (PlazoFijo pf in _listadoPlazosFijos)
                {
                    _acumulador +=
                        Environment.NewLine +
                        pf.ToString() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("Listado de todos los plazos fijos con número de registro 888.086: " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void AltaPF(PlazoFijoNegocio plazoFijoNegocio)
        {
            //Declaración de variables
            //---------------------------------------------------------
            List<PlazoFijo> _listadoPlazosFijos = new List<PlazoFijo>();
            bool _flag;
            string _tipoPlazoFijo = "";
            string _plazoEnDias;
            int _plazoEnDiasValidado = 0;
            string _capitalInicial;
            double _capitalInicialValidado = 0;
            string _registro = "888086";
            string _acuerdo;
            //---------------------------------------------------------


            _listadoPlazosFijos = plazoFijoNegocio.GetLista(_registro); //Traigo la lista de plazos fijos de la capa de negocio          

            ValidacionesInputHelper.FuncionValidacionTipoPlazoFijo(ref _tipoPlazoFijo);

            TipoPlazoFijo _tipoSeleccionado = TipoPlazoFijoFactory.Get(int.Parse(_tipoPlazoFijo));

            do
            {
                Console.WriteLine("Ingrese el plazo (en días) del plazo fijo a agregar");
                _plazoEnDias = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionNumeroNatural(_plazoEnDias, ref _plazoEnDiasValidado, "Plazo");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el capital inicial del plazo fijo a agregar");
                _capitalInicial = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionNumeroEnteroYNatural(_capitalInicial, ref _capitalInicialValidado, "Capital Inicial");

            } while (_flag == false);

            PlazoFijo nuevoPlazoFijo = new PlazoFijo //Instancio la clase 'PlazoFijo' y le asigno todos los inputs validados que ingresó el usuario
                (
                _tipoSeleccionado,
                _plazoEnDiasValidado,
                _capitalInicialValidado,
                _registro
                )
                ;

            Console.WriteLine($"El interés a recibir es {nuevoPlazoFijo.Intereses}");
            Console.WriteLine($"El monto final a recibir es {nuevoPlazoFijo.MontoFinal}");

            Console.WriteLine("Está de acuerdo con el alta? (S/N) ");
            _acuerdo = Console.ReadLine();

            if (_acuerdo == "S")
            {
                plazoFijoNegocio.AgregarPlazoFijo(nuevoPlazoFijo); //Invoco a la función 'AgregarPlazoFijo' de la capa de negocio y le indico que agregue el plazo fijo con los datos que puso el usuario

                Console.WriteLine("El plazo fijo fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void Reportes(PlazoFijoNegocio plazoFijoNegocio)
        {
            //Declaración de variables
            //----------------------------------
            string _opcion = "";
            List<PlazoFijo> _listadoPlazosFijos = new List<PlazoFijo>();
            string _acumulador = "";
            //----------------------------------

            _listadoPlazosFijos = plazoFijoNegocio.GetLista("888086"); //Traigo el listado de plazos fijos de la capa de negocio que a su vez lo trae de la capa de datos

            ValidacionesInputHelper.FuncionValidacionOpcionReportes(ref _opcion);

            if (_opcion == "1")
            {
                Operador o = new Operador(_listadoPlazosFijos);

                Console.WriteLine("El monto total de los plazos fijos es: $" + o.MontoTotal);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

            else if (_opcion == "2")
            {
                Operador o = new Operador(_listadoPlazosFijos);

                Console.WriteLine("La comisión total del operador es de: $" + o.Comision);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
