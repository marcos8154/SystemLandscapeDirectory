using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLD.Controller
{

    public class OperationResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Entity { get; set; }

        public OperationResult(StatusResult status, string msg, object entity)
        {
            Status = (int)status;
            Message = msg;
            Entity = entity;
        }

        public OperationResult()
        {

        }

        public static string ToJson(StatusResult status, string msg, object entity)
        {
            return new OperationResult().GetJson(status, msg, entity);
        }

        public string GetJson(StatusResult status, string msg, object entity)
        {
            Status = (int)status;
            Message = msg;
            Entity = entity;

            return JsonConvert.SerializeObject(this);
        }
    }
}
