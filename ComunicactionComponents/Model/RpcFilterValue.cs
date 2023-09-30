using CookComputing.XmlRpc;
using System.Collections;

namespace ComunicactionComponents.Model
{
    public class RpcFilterValue : ArrayList
    {
        public RpcFilterValue AddValue(object value)
        {
            Add(value);
            return this;
        }
    }
}
