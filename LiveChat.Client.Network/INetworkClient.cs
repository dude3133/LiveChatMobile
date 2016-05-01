using System.Threading.Tasks;

namespace LiveChat.Client.Network
{
    public interface INetworkClient
    {
        Task<T> PostRequst<T>(string url, object content);
        Task<T> GetRequst<T>(string url);
        Task<string> Token(string url, string username, string password);
    }
}
