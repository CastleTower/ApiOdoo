using CookComputing.XmlRpc;

namespace ComunicactionComponents.Interface
{
    [XmlRpcUrl("common")]
    public interface ICommonRpc : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]
        int login(string dbName, string dbUser, string dbPwd);


        [XmlRpcMethod("authenticate")]
        int authenticate(string dbName, string dbUser, string dbPwd, params object[] user_agent_env);
    }
}
