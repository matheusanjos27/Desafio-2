using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_Conversor_Moedas_API_REST
{
    /// <summary>
    /// Desserializa Json.
    /// </summary>
    public class Resultado
    {
        public Motd motd { get; set; }
        public bool success { get; set; }
        public Query query { get; set; }
        public Info info { get; set; }
        public bool historical { get; set; }
        public string date { get; set; }
        public float? result { get; set; }
    }

    public class Motd
    {
        public string msg { get; set; }
        public string url { get; set; }
    }

    public class Query
    {
        public string from { get; set; }
        public string to { get; set; }
        public int? amount { get; set; }
    }

    public class Info
    {
        public float? rate { get; set; }
    }

}
