﻿using MobileAppServer.ServerObjects;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SLD.Controller
{
    public class ConcentradorFiscalController : IController
    {
        public ActionResult Iniciar()
        {
            ActionLocker.AddLock(this, "Iniciar");
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();

                string curDir = Directory.GetCurrentDirectory();
                string caminhoConcentrador = Path.Combine(curDir, @"..\ConcentradorFiscal\");

                info.FileName = $@"{caminhoConcentrador}\ConcentradorNFe.exe";
                info.WorkingDirectory = caminhoConcentrador;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process.Start(info);
                Thread.Sleep(1000);
            }
            catch (Exception ex) { return ActionResult.Json(false, 500, "Erro ao iniciar o Concentrador Fiscal no Servidor"); }

            return ActionResult.Json(true);
        }

        public ActionResult ServidorEmExecucao()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("ConcentradorNFe"))
                    return ActionResult.Json(true);
            }
            catch { }

            return ActionResult.Json(false);
        }

        public ActionResult Parar()
        {
            ActionLocker.AddLock(this, "Parar");
            try
            {
                foreach (Process proc in Process.GetProcessesByName("ConcentradorNFe"))
                    proc.Kill();
            }
            catch { }

            return ActionResult.Json(true);
        }

        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));

            foreach (FileInfo file in source.GetFiles())
            {
                LogController.WriteLog(new ServerLog($"--------> Criando backup de {file.Name}..."));
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
        }

        private void Backup()
        {
            string curDir = Directory.GetCurrentDirectory();
            string caminhoConcentrador = Path.Combine(curDir, @"..\ConcentradorFiscal\");
            string caminhoBackup = Path.Combine(curDir, @"..\ConcentradorFiscal.bak\");
            if (!Directory.Exists(caminhoBackup))
                Directory.CreateDirectory(caminhoBackup);

            CopyFilesRecursively(new DirectoryInfo(caminhoConcentrador), new DirectoryInfo(caminhoBackup));
        }

        private void RestaurarBackup()
        {
            string curDir = Directory.GetCurrentDirectory();
            string caminhoConcentrador = Path.Combine(curDir, @"..\ConcentradorFiscal\");
            string caminhoBackup = Path.Combine(curDir, @"..\ConcentradorFiscal.bak\");
            if (!Directory.Exists(caminhoBackup))
                Directory.CreateDirectory(caminhoBackup);

            CopyFilesRecursively(new DirectoryInfo(caminhoBackup), new DirectoryInfo(caminhoConcentrador));
        }

        public ActionResult BuscarAtualizacao()
        {
            ActionLocker.AddLock(this, "BuscarAtualizacao");
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                LogController.WriteLog(new ServerLog("Buscando atualização para o Concentrador Fiscal..."));
                var credenciais = GoogleDriveController.Autenticar();
                var servico = GoogleDriveController.AbrirServico(credenciais);
                GoogleDriveController.Download(servico, "concentrador.version.v1.txt", @"C:\Temp\concentrador.version.v1.txt");

                string curDir = Directory.GetCurrentDirectory();
                string caminhoConcentrador = Path.Combine(curDir, @"..\ConcentradorFiscal\");

                decimal versaoLocal = decimal.Parse(File.ReadAllText($@"{caminhoConcentrador}\versao.txt"));
                decimal versaoServidor = decimal.Parse(File.ReadAllText($@"C:\Temp\concentrador.version.v1.txt"));

                if (versaoServidor > versaoLocal)
                {
                    Backup();
                    Directory.Delete(caminhoConcentrador, true);

                    LogController.WriteLog(new ServerLog("Obtendo a atualização para o Concentrador Fiscal..."));
                    GoogleDriveController.Download(servico, "concentrador.update.v1.zip", @"C:\Temp\concentrador.update.v1.zip");
                   
                    while (!Directory.Exists(caminhoConcentrador))
                        Directory.CreateDirectory(caminhoConcentrador);

                    LogController.WriteLog(new ServerLog("Instalando a atualização para o Concentrador Fiscal..."));
                    ZipZap zip = new ZipZap();
                    zip.ExtrairArquivoZip(@"C:\Temp\concentrador.update.v1.zip", caminhoConcentrador);

                    LogController.WriteLog(new ServerLog("O Concentrador Fiscal foi atualizado com sucesso"));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "O Concentrador Fiscal foi atualizado com sucesso", ""));
                }
                else
                {
                    LogController.WriteLog(new ServerLog("O Concentrador Fiscal já está atualizado"));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "O Concentrador Fiscal já está atualizado", ""));
                }
            }
            catch (Exception ex)
            {
                RestaurarBackup();

                Console.ForegroundColor = ConsoleColor.Red;
                LogController.WriteLog(new ServerLog("Erro ao obter a atualização para o Concentrador Fiscal: " + ex.Message, ServerLogType.ERROR));
                Console.ForegroundColor = ConsoleColor.Gray;
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_INTERNA, "Erro ao obter a atualização para o Concentrador Fiscal: " + ex.Message, ""));
            }
        }
    }
}
