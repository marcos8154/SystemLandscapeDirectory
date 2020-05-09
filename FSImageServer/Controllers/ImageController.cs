using FSImageServer.Misc;
using SocketAppServer.CoreServices;
using SocketAppServer.ManagedServices;
using SocketAppServer.ServerObjects;
using SocketAppServer.ServerUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FSImageServer.Controllers
{
    public class ImageController : IController
    {
        private ILoggingService Logger { get; set; }
        public ImageController()
        {
            Logger = ServiceManager.GetInstance().GetService<ILoggingService>();
        }

        public ActionResult Upload(string produtoId, string base64Image)
        {
            Logger.WriteLog($"Received image for product {produtoId}, base64 size: {base64Image.Length}", "ImageController", "Upload");

            ImageStorageTask task = new ImageStorageTask();
            task.DoInBackGround(TaskParams.Create()
                .Set("produtoId", produtoId)
                .Set("base64image", base64Image));

            return ActionResult.Json(new OperationResult(true, 600, "A imagem foi recebida e entrará em processamento"));
        }

        public ActionResult Download(string produtoId)
        {
            Logger.WriteLog($"Requested image for product {produtoId}", "ImageController", "Download");

            string key = $"img-prod-{produtoId}";
            Cache<string> cached = CacheRepository<string>.Get(key);
            if (cached != null)
            {
                Logger.WriteLog($"Image for product {produtoId} found in cache. Returning it.", "ImageController", "Download");
                return ActionResult.Json(new OperationResult(cached.Value, 600, ""));
            }

            string path = $@"{Consts.StoragePath}\prod-{produtoId}.jpg";
            if (!File.Exists(path))
            {
                Logger.WriteLog($"Image for product {produtoId} not found in path. Nothing to return.", "ImageController", "Download");
                return ActionResult.Json(new OperationResult(false, 404, "Imagem não encontrada ou ainda não disponível"));
            }

            byte[] arrayImg = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(arrayImg);

            Logger.WriteLog($"Image for product {produtoId} found in path. File buffer length is {arrayImg.Length}. Returning it.", "ImageController", "Download");

            CacheRepository<string>.Set(key, base64, 600);
            return ActionResult.Json(new OperationResult(base64, 600, ""));
        }
    }
}
