using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class Program
    {
        #region Whisper
        //private static TwitchUser userBot = new TwitchUser("bauwsdebug");

        //private static TwitchUser bot = new TwitchBot(userBot,
            //"oauth:20m91p9usq6l1yoi528dtrqfygxmhd");
            
        //internal void Run()
        //{
        //TwitchChatConnection chatConnection = new TwitchChatConnection(IrcBot, false),
        // whisperConnection = new TwitchChatConnection(bot, true);

        //LinkedList<TwitchChannel> channels = new LinkedList<TwitchChannel>();
        //channels.AddLast(new TwitchChannel(userBot));
        ////As many channels as we want

        //foreach (TwitchChannel channel in channels)
        //{
        //new TwitchChatRoom(chatConnection, whisperConnection, channel);
        //}

        //newThread(new ThreadStart(chatConnection.Run)).Start();
        //whisperConnection.Run();
        //}
        #endregion

        static void Main(string[] args)
        {
            IrcBot irc = new IrcBot("irc.twitch.tv", 6667,
                "bauwsdebug", "oauth:20m91p9usq6l1yoi528dtrqfygxmhd");
            Console.WriteLine("Connected to Twitch servers");
            Console.WriteLine("Logging into account");
            irc.joinRoom("bauwsdebug");
            Console.WriteLine("Joining channel: " + "BauwsDebug");
            while (true)
            {
                string message = irc.readMessage();
                if (message.Contains("!test"))
                {
                    irc.sendChatMessage("Testing requested.");
                    Console.WriteLine("Command executed: " + "Testing Requested.");
                    ///TODO find out how to add who triggered the event and then add it to the end
                    ///Console.WriteLine("!test used by " + userName);
                }

            }
        }
    }
}