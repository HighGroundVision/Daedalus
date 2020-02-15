using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Daedalus.GetFriendsList
{
    public class Friend
    {
        public ulong SteamId { get; set; }
        public string Relationship { get; set; }
        public ulong FriendSince { get; set; }
    }
}
