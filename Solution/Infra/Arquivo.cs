using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class Arquivo
    {
        public static void GravarTextoNoFinalDoArquivo(string _texto, string _caminho)
        {
            FileStream fileStream = new FileStream(_caminho, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            streamWriter.WriteLine(_texto);

            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }

        public static void GravarLog(string _texto)
        {
            CriarPasta(Constante.DiretorioDeLog);
            GravarTextoNoFinalDoArquivo(DateTime.Now.ToString() + ": " + _texto, Constante.DiretorioDeLog + "\\" + Constante.NomeArquivoLog);
        }

        public static void CriarPasta(string _caminho)
        {
            Directory.CreateDirectory(_caminho);
        }
    }
}
