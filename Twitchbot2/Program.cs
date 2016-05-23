using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcBot irc = new IrcBot("irc.twitch.tv", 6667,
                "bauwsbot", "oauth:yk1erggcp1egwf527jrwouu7molbp1");
            irc.joinRoom("bauwsbot");
            while (true)
            {
                string message = irc.readMessage();
                if (message.Contains("!test"))
                {
                    irc.sendChatMessage("Testing requested.");
                    ///TODO find out how to add who triggered the event and then add it to the end
                    //Console.WriteLine("!test used by " + )
                }
            }
        }
    }
}
