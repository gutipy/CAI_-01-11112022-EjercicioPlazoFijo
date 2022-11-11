using EjercicioPlazoFijo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Entidades
{
    public class Operador
    {
        private List<PlazoFijo> _plazoFijos;


        public Operador(List<PlazoFijo> lst)
        {
            _plazoFijos = lst;
        }

        public List<PlazoFijo> PlazoFijos { get => _plazoFijos; }
        public double MontoTotal
        {
            get
            {
                double total = 0;

                foreach (var item in _plazoFijos)
                {
                    total = total + item.MontoFinal;
                }

                return total;
            }
        }
        public double Comision
        {
            //get => _plazoFijos.Sum(x=> 15 + (x.Interes * 0.01 ));
            //
            //}

            get
            {
                double comisionTotal = 0;
                double fijo = 15;

                foreach (var item in _plazoFijos)
                {
                    comisionTotal = comisionTotal + (fijo + (item.Intereses * 0.01));
                }

                return comisionTotal;
            }
        }
    }
}

