using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Daedalus.Test
{
    public class MoqSteamKeyProvider : ISteamKeyProvider
    {
        public string GetKey()
        {
            return Environment.GetEnvironmentVariable("SteamKey");
        }
    }
}
