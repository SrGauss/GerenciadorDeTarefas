using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasNaBaseDoOdio
{
    public class ArmazenaCoisa
    {
        public static string ValorCelula { get; set; }

        public static string ColumnName { get; set; }

        public static object IdValue { get; set; }

        public ArmazenaCoisa(string valorCelula, string columnName, object idValue)
        {
            ValorCelula = valorCelula;
            ColumnName = columnName;
            IdValue = idValue;
        }
    }

    public class NovaVariavel
    {
        public static string NovoValorCelula { get; set; }

        public NovaVariavel(string novoValorCelula)
        {
            NovoValorCelula = novoValorCelula;
        }
    }
}
