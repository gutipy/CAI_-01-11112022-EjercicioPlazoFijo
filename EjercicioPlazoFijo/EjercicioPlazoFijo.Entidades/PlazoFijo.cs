using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Entidades
{
    public class PlazoFijo
    {
        //Atributos
        private int _id;
        private int _idCliente;
        private int _tipo;
        private double _tasa;
        private int _dias;
        private double _capitalInicial;
        private string _usuario;
        private TipoPlazoFijo _tipoPlazoFijo;

        //Constructores
        public PlazoFijo()
        {

        }

        public PlazoFijo(TipoPlazoFijo tipoPlazoFijo, int dias, double capitalInicial, string usuario)
        {
            _tipo = tipoPlazoFijo.Id;
            _tasa = tipoPlazoFijo.Tasa;
            _dias = dias;
            _capitalInicial = capitalInicial;
            _usuario = usuario;
            _tipoPlazoFijo = tipoPlazoFijo;
        }

        //Propiedades
        public int Id { get => _id; set => _id = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public int Tipo { get => _tipo; set => _tipo = value; }
        public double Tasa { get => _tasa; set => _tasa = value; }
        public int Dias { get => _dias; set => _dias = value; }
        public double CapitalInicial { get => _capitalInicial; set => _capitalInicial = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public TipoPlazoFijo TipoPlazoFijo { get => _tipoPlazoFijo; set => _tipoPlazoFijo = value; }
        public double Intereses { get => (Tasa / 365 * Dias) * CapitalInicial / 100; }
        public double MontoFinal { get => CapitalInicial + Intereses; }


        //Funciones-Métodos
        public override string ToString()
        {
            return $"{this._id}) {this.Dias} días - ARS {this._capitalInicial} (interés {this.Intereses}) - {this.TipoPlazoFijo.Descripcion}";
        }
    }
}
