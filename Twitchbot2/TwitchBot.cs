using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchBot
    {
        private TwitchUser _user;
        private string _oauthPassword;

        public TwitchBot(TwitchUser user, string oauthPassword)
        {
            _user = user;
            _oauthPassword = oauthPassword;
        }

        #region Getters
        public TwitchUser user
        {
            get
            {
                return _user;
            }
        }

        //Grab this from http://twitchapps.com/tmi
        //oauth:20m91p9usq6l1yoi528dtrqfygxmhd
        public string oauthPassword
        {
            get
            {
                return _oauthPassword;
            }
        }
        #endregion
    }
}
