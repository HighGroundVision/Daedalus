using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Daedalus
{
    public interface ISteamKeyProvider
    {
        string GetKey();
    }

    public class DefaultSteamKeyProvider : ISteamKeyProvider
    {
        public string GetKey()
        {
            throw new NotImplementedException();
        }
    }
}
