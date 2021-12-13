using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private IDictionary<TUser, string> _followed;
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            _followed = new Dictionary<TUser, string>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (_followed.ContainsKey(user))
            {
                return false;
            }
            _followed.Add(new KeyValuePair<TUser, string>(user, group));
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> friends = new List<TUser>();
                foreach (var keyValuePair in _followed)
                {
                    friends.Add(keyValuePair.Key);
                }

                return friends;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            ICollection<TUser> friends = new Collection<TUser>();
            foreach (var keyValuePair in _followed)
            {
                if (keyValuePair.Value.Equals(group))
                {
                    friends.Add(keyValuePair.Key);
                }
            }

            return friends;
        }
    }
}
