using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchChatMessage : TwitchChatChannelEvent
    {
        private string _speaker,
            _message;

        public TwitchChatMessage(string channel, string speaker, string message)
            : base(channel)
        {
            _speaker = speaker;
            _message = message.Trim();
            ///defines the speakers
            ///defines _message and trims it
        }

        public override string ToString()
        {
            return "[" + channel + "]" + _speaker + ": " + message;
            //fix message
            ///returns the above values
        }
    }
}
