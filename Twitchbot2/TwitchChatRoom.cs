using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchChatRoom
    {
        private TwitchChatConnection _chatConnection, _whisperConnection;
        private TwitchChannel _channel;
        //need to make a TwitchChannel class
        //use it to store the channel names????
        //idk will have to think about how to tackle this at a later date

        public TwitchChatRoom(TwitchChatConnection chatConnection,
            TwitchChatConnection whisperConnection, TwitchChannel channel)
        {
            this._chatConnection = chatConnection;
            this._whisperConnection = whisperConnection;
            this._channel = channel;

            chatConnection.Join(this);
        }

        #region Methods
        public void SendChatMessage(string message)
        {
            //fix the .ircClient errors
            //???
            _chatConnection.ircClient.WriteLine(":" + _chatConnection.bot.user.username +
                "!" + _chatConnection.bot.user.username + "@" + _chatConnection.bot.user.username
                + ".tmi.twitch.tv PRIVMSG #" + _channel.username + " :" + message);
        }

        internal void RespondToEvent(TwitchChatChannelEvent channelEvent)
        {
            if(channelEvent.GetType().Equals(typeof(TwitchChatMessage)))
            {
                TwitchChatMessage chatMessage = (TwitchChatMessage)channelEvent;
                if(chatMessage.message.StartsWith("!"))
                    //fix the .message errors???
                {
                    _whisperConnection.SendWhisper(chatMessage.speaker,
                        "Shh, I'm a whispering bot. Try typing this instead: /w "
                        + _chatConnection.bot.user + "help");
                }
            }
        }
        #endregion

        public TwitchChannel channel
        {
            get
            {
                return _channel;
            }
        }
    }
}
