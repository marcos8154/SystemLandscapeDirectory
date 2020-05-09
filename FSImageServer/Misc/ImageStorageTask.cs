using SocketAppServer.CoreServices;
using SocketAppServer.CoreServices.Logging;
using SocketAppServer.ManagedServices;
using SocketAppServer.ServerObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSImageServer.Misc
{
    public class ImageStorageTask : AsyncTask<TaskParams, int, int>
    {
        private ILoggingService Logger { get; set; }
        public ImageStorageTask()
        {
            Logger = ServiceManager.GetInstance().GetService<ILoggingService>();
        }

        private string SaveTemp(string produtoId, string base64Image)
        {
            Logger.WriteLog($"Saving temp image for product {produtoId}. Size: {base64Image.Length}", "ImageStorageTask", "SaveTemp");

            try
            {
                string path = $@"{Consts.TempPath}\prod-{produtoId}.jpg";
                byte[] byteImg = Convert.FromBase64String(base64Image);
                File.WriteAllBytes(path, byteImg);
                return path;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Fail to save temp image for product {produtoId}: {ex.Message}", "ImageStorageTask", "SaveTemp", ServerLogType.ERROR);
                return null;
            }
        }

        private string CompressAndMove(string tempPath)
        {
            FileInfo info = new FileInfo(tempPath);
            string targetPath = $@"{Consts.StoragePath}\{info.Name}";

            Logger.WriteLog($"Compressing file {targetPath}...", "ImageStorageTask", "CompressAndMove");

            using (Bitmap img = new Bitmap(tempPath))
            {
                try
                {
                    //CodecInfo para imagens Jpeg
                    ImageCodecInfo codec = ImageCodecInfo
                        .GetImageEncoders()
                        .First(enc => enc.FormatID == ImageFormat.Jpeg.Guid);

                    EncoderParameters imgParams = new EncoderParameters(1);
                    imgParams.Param = new[] {
                          new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, Consts.QualityLevel)
                     };

                    img.Save(targetPath, codec, imgParams);
                    Logger.WriteLog($"File {targetPath} successfully compressed!");
                }
                catch (Exception ex)
                {
                    Logger.WriteLog($"Fail to compress file {targetPath}: {ex.Message}", "ImageStorageTask", "SaveTemp", ServerLogType.ERROR);
                }
            }

            File.Delete(tempPath);
            return targetPath;
        }

        public override int DoInBackGround(TaskParams param)
        {
            string produtoId = null;
            string base64 = null;
            try
            {
                produtoId = param.GetString("produtoId");
                base64 = param.GetString("base64image");

                Logger.WriteLog($"Proccessing image for product {produtoId}...", "ImageStorageTask", "DoInBackGround");

                string tempImagePath = SaveTemp(produtoId, base64);
                string imgTargetPath = CompressAndMove(tempImagePath);

                byte[] imgFinalBytes = File.ReadAllBytes(imgTargetPath);
                string base64FinalImg = Convert.ToBase64String(imgFinalBytes);

                string key = $"img-prod-{produtoId}";
                CacheRepository<string>.Set(key, base64FinalImg, 600);

                return 1;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Fail to proccess image for product {produtoId}: {ex.Message}", "ImageStorageTask", "DoInBackGround", ServerLogType.ERROR);
                return 0;
            }
        }

        public override void OnPostExecute(int result)
        {
        }

        public override void OnPreExecute()
        {
        }

        public override void OnProgressUpdate(int progress)
        {

        }
    }
}
