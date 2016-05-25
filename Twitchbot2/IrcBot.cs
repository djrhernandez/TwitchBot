using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Twitchbot2
{
    public class IrcBot : BauwsTcpClient
    {
        private string userName;
        private string channel;

        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        public IrcBot(string ip, int port, string userName, string password)
            : base(ip, port, 2000)
        {
            this.userName = userName;

            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + userName);
            outputStream.WriteLine("USER " + userName + " 8 * :" + userName);
            outputStream.Flush();
        }

        public void joinRoom(string channel)
        {
            this.channel = channel;
            outputStream.WriteLine("Join #" + channel);
            outputStream.Flush();
            ///joins the channel
        }

        public void sendIrcMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
            ///writes the message
        }

        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + userName + "!" + userName + "@" + userName +
                "tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
            ///connection information so it can connect to the servers
            ///not my code, grabbed it from the interwebs
            ///Kappa
        }

        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
            ///method to read the chat
        }
    }
}
