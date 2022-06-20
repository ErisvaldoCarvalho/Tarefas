using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class Constante
    {
        public static string DiretorioDeLog = Environment.CurrentDirectory + "\\Logs";
        public static string NomeArquivoLog = "Log" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".txt";
    }
}
