using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    public class IrcClient : BauwsTcpClient
    {
        private string userName;

        public IrcClient(string ip, int port, string username, string password)
            : base(ip, port, 2000)
        {
            //Ask Kyle/David????
            //Too fucking tired to think atm
            this.userName = userName;

            WriteLine("PASS " + password + Environment.NewLine + "NICK " +
                userName + Environment.NewLine + "USER " + userName + " 8 * :" + userName);
        }
    }
}
