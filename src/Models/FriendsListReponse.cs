using System.Collections.Generic;

namespace HGV.Daedalus.Models
{
	public class FriendsListReponse
	{
		[Newtonsoft.Json.JsonProperty("friendslist")]
		public FriendsList FriendsList { get; set; }
	}

	public class FriendsList
    {
        [Newtonsoft.Json.JsonProperty("friends")]
        public List<Friend> Friends { get; set; }
    }
}
