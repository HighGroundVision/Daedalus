using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HGV.Daedalus.Test
{
    public class MoqHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient();
        }
    }
}
