using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RESTFulSense.Clients;

namespace ProductAPI.Tests.Acceptance.Brokers
{
    public class ProductApiBroker
    {
        private readonly WebApplicationFactory<Program>? _webApplicationFactory;
        private readonly HttpClient? _httpClient;
        private readonly IRESTFulApiFactoryClient? _apiFactoryClient;

        public ProductApiBroker()
        {
            this._webApplicationFactory = new WebApplicationFactory<Program>();
            this._httpClient = this._webApplicationFactory.CreateClient();
            this._apiFactoryClient = new RESTFulApiFactoryClient(this._httpClient);
        }
    }
}
