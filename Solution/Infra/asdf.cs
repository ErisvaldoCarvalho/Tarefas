//using System;
//using System.IO;
//using System.Text;
//using System.Diagnostics;
//using System.Collections;
//using System.Security.Cryptography;

//namespace Infra
//{
//    //public class Arquivo
//    //{
//    //    public ArrayList LerArquivo(string _caminho)
//    //    {
//    //        ArrayList retorno = new ArrayList();
//    //        StreamReader sr = new StreamReader(_caminho);
//    //        string linha = sr.ReadLine();

//    //        while (linha != null)
//    //        {
//    //            retorno.Add(linha);
//    //            linha = sr.ReadLine();
//    //        }
//    //        sr.Close();

//    //        return retorno;
//    //    }

//    //    public void GravarLinhaNoFinalDoArquivo(string _caminho, string _texto)
//    //    {
//    //        StreamWriter sw = new StreamWriter(_caminho);
//    //        sw.WriteLine(_texto);
//    //        sw.Close();
//    //    }
//    //    public void CriarPasta(string _caminho)
//    //    {
//    //        throw new NotImplementedException();
//    //    }
//    //}


//    /// <summary>
//    /// Esta classe é utilizada para manipular arquivos
//    /// podendo copiar, excluir, renomear, checar existencia...
//    /// entre outras ações.
//    /// </summary>
//    public class asdf
//    {
//        public static ArrayList LerArquivo(string _arquivo)
//        {
//            ArrayList Retorno = new ArrayList();

//            FileInfo arquivo = new FileInfo(_arquivo);
//            StreamReader sr = new StreamReader(arquivo.FullName, Encoding.Default);

//            string linha;

//            while (!sr.EndOfStream)
//            {
//                linha = sr.ReadLine();
//                Retorno.Add(linha);
//            }

//            return Retorno;
//        }

//        /// <summary>
//        /// Metodo para escrever texto na ultima linha de um arquivo
//        /// </summary>
//        /// <param name="_linha">Informe a mensagem que gostaria de escrever</param>
//        /// <param name="_arquivo">Informe o caminho juntamente com o nome do arquivo</param>
//        /// <example>GravarLinhaNoFinalDoArquivo("mensagem teste de gravação",@"C:\teste\log.txt");</example>
//        /// <!--Metodo já testado-->
//        public static void GravarLinhaNoFinalDoArquivo(string _linha, string _arquivo)
//        {
//            FileStream arquivo = new FileStream(_arquivo, FileMode.Append);
//            StreamWriter sw = new StreamWriter(arquivo, Encoding.UTF8);
//            sw.WriteLine(_linha);

//            sw.Flush();
//            sw.Close();
//            arquivo.Close();
//        }

//        /// <summary>
//        /// Carrega caminho para salvar arquivo
//        /// </summary>
//        /// <param name="_Titulo">Informe o titulo do SaveFileDialog</param>
//        /// <param name="_DiretorioInicial">Informe o diretório inicial</param>
//        /// <param name="ExtencaoDefault">Informe a extenção padrão</param>
//        /// <param name="Filtro">Informe o filtro de extenção</param>
//        /// <example>
//        /// SalvarArquivo("Titulo do arquivo", "C:\\Teste",".jpg","Arquivos JPG|*.jpg|Arquivos GIF|*.gif");
//        /// 
//        /// OU
//        ///
//        /// SalvarArquivo("Titulo do arquivo", "C:\\Teste",".jpg","Imagem|*.jpg;*.gif;*.png");
//        /// </example>
//        /// <returns></returns>
//        //public static string SalvarArquivo(string _Titulo, string _DiretorioInicial, string ExtencaoDefault, string Filtro)
//        //{
//        //    try
//        //    {
//        //        System.Windows.Forms.SaveFileDialog SalvarArquivo = new System.Windows.Forms.SaveFileDialog();

//        //        SalvarArquivo.Title = _Titulo;
//        //        SalvarArquivo.InitialDirectory = _DiretorioInicial;
//        //        SalvarArquivo.FileName = string.Empty;
//        //        SalvarArquivo.DefaultExt = ExtencaoDefault;
//        //        SalvarArquivo.Filter = Filtro;
//        //        SalvarArquivo.RestoreDirectory = true;

//        //        if (SalvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//        //        {
//        //            return SalvarArquivo.FileName;
//        //        }
//        //        return "";
//        //    }
//        //    catch (Exception)
//        //    {

//        //        throw;
//        //    }
//        //}

//        /// <summary>
//        /// Carrega arquivo do HD utilizando OpenFileDialog
//        /// </summary>
//        /// <param name="_Titulo">Informe o titulo do OpenFileDialog</param>
//        /// <param name="_DiretorioInicial">Informe o diretório inicial</param>
//        /// <param name="ExtencaoDefault">Informe a extenção padrão</param>
//        /// <param name="Filtro">Informe o filtro de estenção</param>
//        /// <example>
//        /// BuscarArquivo("Titulo do arquivo", "C:\\Teste",".jpg","Arquivos JPG|*.jpg|Arquivos GIF|*.gif");
//        /// 
//        /// OU
//        ///
//        /// BuscarArquivo("Titulo do arquivo", "C:\\Teste",".jpg","Imagem|*.jpg;*.gif;*.png");
//        /// /// 
//        /// </example>
//        /// <returns></returns>
//        //public static string BuscarArquivo(string _Titulo, string _DiretorioInicial, string ExtencaoDefault, string Filtro)
//        //{
//        //    System.Windows.Forms.OpenFileDialog AbrirArquivo = new System.Windows.Forms.OpenFileDialog();

//        //    AbrirArquivo.Title = _Titulo;
//        //    AbrirArquivo.InitialDirectory = _DiretorioInicial;
//        //    AbrirArquivo.FileName = string.Empty;
//        //    AbrirArquivo.DefaultExt = ExtencaoDefault;
//        //    AbrirArquivo.Filter = Filtro;
//        //    AbrirArquivo.RestoreDirectory = true;

//        //    if (AbrirArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//        //    {
//        //        return AbrirArquivo.FileName;
//        //    }
//        //    return "";
//        //}

//        /// <summary>
//        /// Metodo para saber se o arquivo ou um diretório existe
//        /// </summary>
//        /// <param name="Arquivo">Informe o caminho do arquivo ou do diretório que deseja verificar</param>
//        /// <example>Existe("C:\\Log\\Teste.TXT");</example>
//        /// <returns>Se o arquivo existir retorna TRUE, senão retorna FALSE</returns>
//        /// <!--Metodo já testado-->
//        public static bool Existe(string _arquivo, bool _diretorio)
//        {
//            if (_diretorio)
//                return Directory.Exists(_arquivo);

//            return File.Exists(_arquivo);
//        }

//        /// <summary>
//        /// Metodo para deletar arquivo
//        /// </summary>
//        /// <param name="_raizDiretorio">Informe a raiz do arquivo</param>
//        /// <param name="_caminhoArquivo">Informe o caminho do arquivo</param>
//        /// <example>DeletarArquivo("C:\\","TESTE\\TESTE.TXT");</example>
//        /// <returns>Se operação realizada com sucesso, retorna TRUE, senão Retorna FALSE</returns>
//        /// <!--Metodo já testado-->
//        public static bool DeletarArquivo(string _raizDiretorio, string _caminhoArquivo)//, string Arquivo)
//        {
//            try
//            {
//                FileInfo Arquivo = new FileInfo(_caminhoArquivo);
//                DirectoryInfo diretorioArquivo = new DirectoryInfo(_raizDiretorio);
//                if (diretorioArquivo.Exists)
//                    Arquivo.Delete();
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// Carrega o arquivo do disco byte a byte.
//        /// </summary>
//        /// <param name="caminhoOrigem">Informe o caminho do arquivo a ser carregado</param>
//        /// <returns>Retorna o arquivo carregado do disco</returns>
//        /// <!--Metodo já testado-->
//        public static byte[] CarregarArquivo(string _caminhoArquivo)
//        {
//            FileInfo arquivo = new FileInfo(_caminhoArquivo);
//            long Bytes = arquivo.Length;
//            FileStream fStream = new FileStream(_caminhoArquivo, FileMode.Open, FileAccess.Read);
//            BinaryReader bReader = new BinaryReader(fStream);
//            byte[] dados = bReader.ReadBytes((int)Bytes);
//            fStream.Close();
//            return dados;
//        }

//        /// <summary>
//        /// Copia arquivo de um diretorio para outro, substituindo o arquivo existente
//        /// </summary>
//        /// <param name="Origem">Informe o diretorio de origem</param>
//        /// <param name="Destino">Informe o diretorio de destino</param>
//        /// <param name="NomeArquivo">Informe o nome do arquivo a ser copiado</param>
//        /// <!--Metodo já testado-->
//        public static void CopiarArquivo(string Origem, string Destino, string NomeArquivo)
//        {
//            string Arquivo = NomeArquivo;

//            // Crie uma nova pasta de estino, se necessario.
//            CriarDiretorio(Destino);

//            //verifica se o diretorio de destino existe
//            if (System.IO.Directory.Exists(Destino))
//            {
//                string ArquivoOrigem = System.IO.Path.Combine(Origem, Arquivo);
//                string ArquivoDestino = System.IO.Path.Combine(Destino, Arquivo);

//                //Para copiar um ariquivo para outro local e sobrescrever o existente
//                System.IO.File.Copy(ArquivoOrigem, ArquivoDestino, true);
//            }
//        }

//        /// <summary>
//        /// Metodo para criar diretório
//        /// </summary>
//        /// <param name="Destino">Passe o caminho do diretório que deseja criar</param>
//        public static void CriarDiretorio(string Destino)
//        {
//            //se não existir o diretório será criado
//            if (!System.IO.Directory.Exists(Destino))
//            {
//                System.IO.Directory.CreateDirectory(Destino);
//                //return "Diretório criado com sucesso!";
//            }
//            else
//            {
//                //return "Diretório já existe!";
//            }
//        }


//        /// <summary>
//        /// metodo para excluir arquivo
//        /// </summary>
//        /// <param name="Origem">informe o caminho do arquivo com o arquivo</param>
//        /// <example>ExcluirArquivo(@"C:\SISTEMA\TESTE.TXT");</example>
//        /// <!--Metodo já testado-->
//        public static void ExcluirArquivo(string Origem)
//        {
//            if (Existe(Origem, false))
//            {
//                System.IO.File.Delete(Origem);
//            }

//            #region Deletar
//            // ...or by using FileInfo instance method.
//            //System.IO.FileInfo fi = new System.IO.FileInfo(@"C:\Users\Public\DeleteTest\test2.txt");
//            //try
//            //{
//            //    fi.Delete();
//            //}
//            //catch (System.IO.IOException e)
//            //{
//            //    Console.WriteLine(e.Message);
//            //}

//            // Delete a directory. Must be writable or empty.
//            //try
//            //{
//            //    System.IO.Directory.Delete(Origem);
//            //}
//            //catch (System.IO.IOException e)
//            //{
//            //    Console.WriteLine(e.Message);
//            //}
//            //// Delete a directory and all subdirectories with Directory static method...
//            //if (System.IO.Directory.Exists(Origem))
//            //{
//            //    try
//            //    {
//            //        System.IO.Directory.Delete(Origem, true);
//            //    }

//            //    catch (System.IO.IOException e)
//            //    {
//            //        Console.WriteLine(e.Message);
//            //    }
//            //}

//            //// ...or with DirectoryInfo instance method.
//            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Origem);
//            //// Delete this dir and all subdirs.
//            //try
//            //{
//            //    di.Delete(true);
//            //}
//            //catch (System.IO.IOException e)
//            //{
//            //    Console.WriteLine(e.Message);
//            //}
//            #endregion
//        }

//        /// <summary>
//        /// Metodo para excluir um diretorio que esteja vazio
//        /// </summary>
//        /// <param name="Origem">Informe o caminho do diretorio que deseja excluir</param>
//        /// <example>ExcluirDiretorioVazio(@"C:\SISTEMA\TESTE");</example>
//        public static void ExcluirDiretorioVazio(string Origem)
//        {
//            try
//            {
//                System.IO.Directory.Delete(Origem);
//            }
//            catch (System.IO.IOException e)
//            {
//                Console.WriteLine(e.Message);
//            }

//        }

//        /// <summary>
//        /// Metodo para excluir diretório e subdiretórios
//        /// </summary>
//        /// <param name="Origem">Informe o caminho do diretório que deseja excluir</param>
//        /// <example>ExcluirDiretorioESubDiretorios(@"C:\SISTEMA\TESTE");</example>
//        public static void ExcluirDiretorioESubDiretorios(string Origem)
//        {
//            if (Existe(Origem, true))
//            {
//                try
//                {
//                    System.IO.Directory.Delete(Origem, true);
//                }

//                catch (System.IO.IOException e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }


//        /// <summary>
//        /// Chama um arquivo passado por parametro
//        /// </summary>
//        /// <param name="Origem">Arquivo a ser execultado</param>
//        /// <!--Metodo já testado-->
//        public static void ExecutarArquivo(string Origem)
//        {
//            if (Existe(Origem, false))
//                Process.Start(Origem);
//        }

//        /// <summary>
//        /// Chama um arquivo passado por parametro
//        /// </summary>
//        /// <param name="Origem">Arquivo a ser execultado</param>
//        /// <!--Metodo já testado-->
//        public static void ExecutarArquivo(string Origem, string Args)
//        {
//            if (Existe(Origem, false))
//                Process.Start(Origem, Args);
//        }

//        /// <summary>
//        /// Metodo para renomear um arquivo
//        /// </summary>
//        /// <param name="NomeAntigo">Informe o caminho juntamente com o antigo nome do arquivo</param>
//        /// <param name="NomeNovo">Informe o caminho juntamente com o novo nome do artivo</param>
//        public static void RenomearArquivo(string NomeAntigo, string NomeNovo)
//        {
//            // vamos renomear o arquivo
//            if (Existe(NomeAntigo, false))
//                if (!Existe(NomeNovo, false))
//                    File.Move(NomeAntigo, NomeNovo);
//        }

//        /// <summary>
//        /// Metodo utilizado para mover arquivos de um diretório para outro
//        /// </summary>
//        /// <param name="Origem">Informe o caminho de origem juntamente com o nome do arquivo</param>
//        /// <param name="Destino">Informe o caminho de destino juntamente com o nome do arquivo</param>
//        public static void MoverArquivo(string Origem, string Destino, bool SubstituirExistente)
//        {
//            try
//            {
//                if (Existe(Origem, false))
//                    if (SubstituirExistente || !Existe(Destino, false))
//                    {
//                        ExcluirArquivo(Destino);
//                        File.Move(Origem, Destino);
//                    }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        public static ArrayList RetornarListaArquivos(string caminho)
//        {
//            try
//            {
//                ArrayList retorno = new ArrayList(System.IO.Directory.GetFiles(caminho));
//                return retorno;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public static ArrayList RetornarListaDiretorios(string caminho)
//        {
//            try
//            {
//                ArrayList retorno = new ArrayList(System.IO.Directory.GetDirectories(caminho));
//                return retorno;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public static string RetornarDiretorio()
//        {
//            try
//            {
//                System.Windows.Forms.FolderBrowserDialog diretorio = new System.Windows.Forms.FolderBrowserDialog();

//                if (diretorio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//                {
//                    return diretorio.SelectedPath;
//                }
//                return "";
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public enum TipoHash { MD5, SHA1 }

//        public static string GerarHash(string caminho, TipoHash tipoHash)
//        {
//            try
//            {
//                StringBuilder sb = new StringBuilder();
//                using (FileStream arquivo = new FileStream(caminho, FileMode.Open))
//                {
//                    HashAlgorithm hash;
//                    if (tipoHash == TipoHash.MD5)
//                    {
//                        hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
//                    }
//                    else
//                    {
//                        hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
//                    }

//                    if (hash != null)
//                    {
//                        byte[] retVal = hash.ComputeHash(arquivo);
//                        for (int i = 0; i < retVal.Length; i++)
//                        {
//                            sb.Append(retVal[i].ToString("x2"));
//                        }

//                    }
//                }
//                return sb.ToString();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//    }

//}
