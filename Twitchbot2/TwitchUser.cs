using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class TwitchUser
    {
        private uint _id;
        private string _name, _displayName;
        private DateTime _createdAt,
            _updatedAt;
        private string _logo,
            _bio;

        #region Constructors
        public TwitchUser(string displayName, uint id = 0, DateTime? createdAt = null,
            DateTime? updatedAt = null, string logo = null, string bio = null)
        {
            _id = id;
            _name = displayName.ToLower();
            _displayName = displayName;
            _createdAt = createdAt == null ? DateTime.MinValue : createdAt.Value;
            _updatedAt = updatedAt == null ? DateTime.MinValue : updatedAt.Value;
            _logo = logo;
            _bio = bio;
        }

        //
        //Can add database support here if the feature is wanted in the future//
        //

        public TwitchUser(TwitchUser user) : this(user.displayName, user.id, user.createdAt,
            user.updatedAt, user.logo, user.bio)
        {
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return _displayName;
        }
        #endregion

        #region Getters
        public uint id
        {
            get
            {
                return _id;
            }
        }

        public string username
        {
            get
            {
                return _name;
            }
        }

        public string displayName
        {
            get
            {
                return _displayName;
            }
        }

        public DateTime updatedAt
        {
            get
            {
                return _updatedAt;
            }
        }

        public DateTime createdAt
        {
            get
            {
                return _createdAt;
            }
        }

        public string logo
        {
            get
            {
                return _logo;
            }
        }

        public string bio
        {
            get
            {
                return _bio;
            }
        }
        #endregion
    }
}
