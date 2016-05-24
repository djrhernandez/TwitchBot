using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchChatChannelEvent : TwitchChatEvent
    {
        private string _channel;

        public TwitchChatChannelEvent(string channel)
        {
            _channel = channel;
        }

        public string channel
        {
            get
            {
                return _channel;
            }
        }
    }
}
