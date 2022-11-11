using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Entidades
{
    public class TipoPlazoFijo
    {
        //Atributos
        private int _id;
        private double _tasa;
        private string _descripcion;

        //Constructores
        public TipoPlazoFijo(int id, double tasa, string descripcion)
        {
            _id = id;
            _tasa = tasa;
            _descripcion = descripcion;
        }

        //Propiedades
        public int Id { get => _id; set => _id = value; }
        public double Tasa { get => _tasa; set => _tasa = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        //Funciones-Métodos
        public override string ToString()
        {
            return $"{Id}) {Descripcion} - {Tasa} %";
        }
    }
}
