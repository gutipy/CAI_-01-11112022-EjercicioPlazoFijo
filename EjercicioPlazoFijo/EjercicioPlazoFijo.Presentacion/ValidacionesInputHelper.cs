using EjercicioPlazoFijo.Entidades;
using EjercicioPlazoFijo.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Presentacion
{
    internal static class ValidacionesInputHelper
    {
        internal static string FuncionValidacionTipoPlazoFijo(ref string tipoPlazoFijo)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                Console.WriteLine("Ingrese el tipo de plazo fijo a agregar");

                foreach (TipoPlazoFijo item in TipoPlazoFijoFactory.Get())
                {
                    Console.WriteLine(item.ToString());
                }

                tipoPlazoFijo = Console.ReadLine();

                if (string.IsNullOrEmpty(tipoPlazoFijo))
                {
                    Console.WriteLine("ERROR! El tipo de plazo fijo ingresado no puede ser vacío, intente nuevamente.");
                }
                else if (tipoPlazoFijo == "1" || tipoPlazoFijo == "2")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! El tipo de plazo fijo " + tipoPlazoFijo + " no es un tipo de plazo fijo válido, intente nuevamente.");
                }
            } while (flag == false);

            return tipoPlazoFijo;
        }

        internal static bool FuncionValidacionNumeroNatural(string numero, ref int numeroValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(numero))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!int.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (numeroValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static bool FuncionValidacionNumeroEnteroYNatural(string numero, ref double numeroValidado, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(numero))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }

            else if (!double.TryParse(numero, out numeroValidado))
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " debe ser de tipo numérico, intente nuevamente.");
            }

            else if (numeroValidado <= 0)
            {
                Console.WriteLine("ERROR! El valor ingresado para el campo " + campo + " no debe ser negativo, intente nuevamente.");
            }

            else
            {
                flag = true;
            }

            return flag;
        }

        internal static string FuncionValidacionOpcionReportes(ref string opcionReportes)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                Console.WriteLine(
                "Que tipo de reporte desea visualizar?" + Environment.NewLine +
                "1 - Monto total de los plazos fijos" + Environment.NewLine +
                "2 - Comisión total del operador" + Environment.NewLine
                )
                ;

                opcionReportes = Console.ReadLine();

                if (string.IsNullOrEmpty(opcionReportes))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcionReportes == "1" || opcionReportes == "2")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción ingresada " + opcionReportes + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcionReportes;
        }
    }
}
