using EjercicioPlazoFijo.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPlazoFijo.Datos
{
    public class PlazoFijoMapper
    {
        public List<PlazoFijo> Get(string registro)
        {
            string json2 = WebHelper.Get("/api/v1/plazofijo/" + registro);
            List<PlazoFijo> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(PlazoFijo pzoFijo)
        {
            NameValueCollection obj = ReverseMap(pzoFijo);

            string result = WebHelper.Post("/api/v1/PlazoFijo", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<PlazoFijo> MapList(string json)
        {
            List<PlazoFijo> lst = JsonConvert.DeserializeObject<List<PlazoFijo>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(PlazoFijo pzoFijo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("idCliente", pzoFijo.IdCliente.ToString());
            n.Add("id", pzoFijo.Id.ToString());

            n.Add("Tipo", pzoFijo.Tipo.ToString());
            n.Add("CapitalInicial", pzoFijo.CapitalInicial.ToString("0.00"));
            n.Add("Dias", pzoFijo.Dias.ToString());
            n.Add("Interes", pzoFijo.Intereses.ToString("0.00"));
            n.Add("Usuario", pzoFijo.Usuario);

            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
