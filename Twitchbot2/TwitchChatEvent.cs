using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    //TODO needs work
    public abstract class TwitchChatEvent
    {
        internal static TwitchChatEvent Parse(string chatEventCommand)
        {
            string command;

            if (chatEventCommand.StartsWith("PING"))
            {
                command = "PING";
            }
            else
            {
                command = BauwsStrings.TextBetween(chatEventCommand, " ", " ");
            }

            if (command.Equals("PRIVMSG"))
            {
                string channel = ParseChannel(chatEventCommand);
                string username = ParseUsername(chatEventCommand);
                //add .TextAfter???
                string message = BauwsStrings.TextAfter(chatEventCommand, "#" + channel + " :");

                return new TwitchChatMessage(channel, username, message);
            }
            else if (command.Equals("WHISPER"))
            {
                string username = ParseUsername(chatEventCommand);
                string message = BauwsStrings.TextAfter(chatEventCommand, " :");

                //??????????
                //fuck sleep, can't think straight, fix later
                return new TwitchChatWhisper(username, message);
            }
            else if (command.Equals("PING"))
            {
                return new TwitchChatPing();
            }
            else
            {
                //make a new class for this
                //what goes in it????
                return new TwitchChatUnknownEvent(chatEventCommand);
            }
        }

        #region Helpers
        private static string ParseUsername(string chatEventCommand)
        {
            return BauwsStrings.TextBetween(chatEventCommand, ":", "!");
        }

        private static string ParseChannel(string chatEventCommand)
        {
            return BauwsStrings.TextBetween(chatEventCommand, " #", " ");
        }
        #endregion
    }
}
