using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchChatWhisper
    {
        private string _speaker, _message;

        public TwitchChatWhisper(string username, string message)
        {
            _speaker = username;
            _message = message;
            ///defines speakers and message
        }

        public override string ToString()
        {
            return "*" + _speaker + "*: " + _message;
        }

        #region Getters
        //use this if needed
        //can't remember the original purpose for this
        //i'm stupid
        #endregion
    }
}
