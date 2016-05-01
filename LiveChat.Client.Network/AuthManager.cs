using LiveChat.Client.Network.Models;
using System.Threading.Tasks;

namespace LiveChat.Client.Network
{
    public class AuthManager
    {
        private INetworkClient network = new NetworkClient();
        public async Task<string> Login(string login,string password)
        {
            string token = "";

            var x = await network.Token("http://livechat-3.apphb.com/token", login, password);

            return x;
        }
    }
}
