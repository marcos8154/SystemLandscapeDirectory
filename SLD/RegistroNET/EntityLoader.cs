using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.RegistroNET
{
    public class EntityLoader<T>
    {
        public static T Load(OperationResult result)
        {
            try
            {
                if (result.Entity == null)
                    return default(T);
                return JsonConvert.DeserializeObject<T>(result.Entity.ToString());
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
