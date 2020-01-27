using Ionic.Zip;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SLD
{
    public class ZipZap
    {
        public static void CriarArquivoZip(List<string> arquivos, string ArquivoDestino)
        {
            using (ZipFile zip = new ZipFile())
            {
                // percorre todos os arquivos da lista
                foreach (string item in arquivos)
                {
                    // se o item é um arquivo
                    if (File.Exists(item))
                    {
                        try
                        {
                            // Adiciona o arquivo na pasta raiz dentro do arquivo zip
                            zip.AddFile(item, "");
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    // se o item é uma pasta
                    else if (Directory.Exists(item))
                    {
                        try
                        {
                            // Adiciona a pasta no arquivo zip com o nome da pasta 
                            zip.AddDirectory(item, new DirectoryInfo(item).Name);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                // Salva o arquivo zip para o destino
                try
                {
                    zip.Save(ArquivoDestino);
                }
                catch
                {
                    throw;
                }
            }
        }

        public void ExtrairArquivoZip(string localizacaoArquivoZip, string destino,
            string senha = "")
        {
            string arquivoAtual = "";
            if (File.Exists(localizacaoArquivoZip))
            {
                //recebe a localização do arquivo zip
                using (ZipFile zip = new ZipFile(localizacaoArquivoZip))
                {
                    if (!string.IsNullOrEmpty(senha))
                        zip.Password = senha;
                    if (Directory.Exists(destino))
                        zip.ExtractAll(destino, ExtractExistingFileAction.OverwriteSilently);
                    else
                    {
                        //lança uma exceção se o destino não existe
                        throw new DirectoryNotFoundException("O arquivo destino não foi localizado, arquivo: " + arquivoAtual);
                    }
                }
            }
            else
            {
                //lança uma exceção se a origem não existe
                throw new FileNotFoundException("O Arquivo Zip não foi localizado");
            }
        }
    }
}
