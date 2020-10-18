using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Daedalus.Models
{
    public class Friend
    {
        [Newtonsoft.Json.JsonProperty("steamid")]
        public ulong SteamId { get; set; }

        [Newtonsoft.Json.JsonProperty("relationship")]
        public string Relationship { get; set; }

        [Newtonsoft.Json.JsonProperty("friend_since")]
        public ulong FriendSince { get; set; }
    }
}
