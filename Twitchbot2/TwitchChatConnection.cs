﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    //TODO Needs work
    class TwitchChatConnection
    {
        private TwitchBot _bot;
        private IrcBot _ircBot;
        private LinkedList<TwitchChatRoom>
            chatRooms = new LinkedList<TwitchChatRoom>();

        ///connection information
        public TwitchChatConnection(TwitchBot bot, bool whisperServer)
        {
            this._bot = bot;
            string ircServer = "irc.twitch.tv";
            ///public ip of the server
            if(whisperServer)
            {
                ircServer = "199.9.253.119";
                ///actual ip of the server
            }

            this._ircBot = new IrcBot(ircServer, 6667, bot.user.username, bot.oauthPassword);

            if(whisperServer)
            {
                //fix this
                ircClient.WriteLine("CAP REQ :twitch.tv/commands");
                ///send this to the server to ensure that you can receive whispers on the IRC
            }
        }

        #region Methods
        internal void Join(TwitchChatRoom room)
        {
            ircClient.WriteLine("JOIN #" + room.channel.username);
            chatRooms.AddLast(room);
            ///adds the last room joined to the chatRooms list
        }

        internal void Run()
        {
            while(true)
            {
                TwitchChatEvent chatEvent = GetNextChatEvent();
                RespondToEvent(chatEvent);
                ///grab the next event (chat message?)
                ///respond to the event
            }
        }

        internal void SendWhisper(string speakee, string message)
        {
            ircClient.WriteLine("PRIVMSG #jtv :/w " + speakee + " " + message);
            ///code on how it responds in chat to active whispers
        }
        #endregion

        #region Helpers
        private TwitchChatEvent GetNextChatEvent()
        {
            string chatEventCommand = ircClient.ReadNextLine_BLOCKING();
            return TwitchChatEvent.Parse(chatEventCommand);
        }

        private void RespondToEvent(TwitchChatEvent charEvent)
        {
            //need the Log library???
            //import that
            Log.Message(chatEvent.ToString());

            //fix chatEvent
            if(chatEvent.GetType().Equals(typeof(TwitchChatWhisper)))
            {
                TwitchChatWhisper whisper = (TwitchChatWhisper)chatEvent;
                //echo the response? useful for later?
                //SendWhisper(whisper.speaker, "You said: " + whisper.message);
                SendWhisper(whisper.speaker, 
                    //fix speaker?
                    "This is a bot account, please do not whisper it");
            }
            else if(chatEvent.GetType().IsSubclassOf(typeof(TwitchChatChannelEvent)))
            {
                TwitchChatChannelEvent channelEvent = (TwitchChatChannelEvent)chatEvent;
                foreach (TwitchChatRoom room in chatRooms)
                {
                    if (room.channel.username.Equals(channelEvent.channel))
                    {
                        room.RespondToEvent(channelEvent);
                        break;
                    }
                }
            }
            else if(chatEvent.GetType().Equals(typeof(TwitchChatPing)))
            {
                //fix this
                ircClient.WriteLine("PONG");
            }
        }

        #endregion

        #region Getters

        #endregion
    }
}
