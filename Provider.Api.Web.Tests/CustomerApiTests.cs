using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Owin.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace Provider.Api.Web.Tests
{
    public class CustomerApi : IDisposable
    {
        private readonly ITestOutputHelper _output;

        public CustomerApi(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void EnsureAllCustomers_Status_ApiHonoursPactWithConsumer()
        {
            //Arrange
            const string serviceUri = "http://localhost:9222";
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                }
            };
            
            using (WebApp.Start<TestStartup>(serviceUri))
            {
                //Act / Assert
                IPactVerifier pactVerifier = new PactVerifier(config);
                pactVerifier
                    .ProviderState($"{serviceUri}/provider-states")
                    .ServiceProvider("Customer Status API", serviceUri)
                    .HonoursPactWith("Customer Status API Consumer")
                    .PactUri($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}AllCustomers_Status_ConsumerTests{Path.DirectorySeparatorChar}pacts{Path.DirectorySeparatorChar}customer_status_api_consumer-customer_status_api.json")
                    .Verify();
            }
        }

        [Fact]
        public void EnsureAllCustomers_Balance_ApiHonoursPactWithConsumer()
        {
            //Arrange
            const string serviceUri = "http://localhost:9222";
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                }
            };

            using (WebApp.Start<TestStartup>(serviceUri))
            {
                //Act / Assert
                IPactVerifier pactVerifier = new PactVerifier(config);
                pactVerifier
                    .ProviderState($"{serviceUri}/provider-states")
                    .ServiceProvider("Customer Balance API", serviceUri)
                    .HonoursPactWith("Customer Balance API Consumer")
                    .PactUri($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}AllCustomers_Balance_ConsumerTests{Path.DirectorySeparatorChar}pacts{Path.DirectorySeparatorChar}customer_balance_api_consumer-customer_balance_api.json")
                    .Verify();
            }
        }

        [Fact]
        public void EnsureCustomer_Search_ApiHonoursPactWithConsumer()
        {
            //Arrange
            const string serviceUri = "http://localhost:9222";
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                }
            };

            using (WebApp.Start<TestStartup>(serviceUri))
            {
                //Act / Assert
                IPactVerifier pactVerifier = new PactVerifier(config);
                pactVerifier
                    .ProviderState($"{serviceUri}/provider-states")
                    .ServiceProvider("Customer Search API", serviceUri)
                    .HonoursPactWith("Customer Search API Consumer")
                    .PactUri($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Customer_Search_ConsumerTests{Path.DirectorySeparatorChar}pacts{Path.DirectorySeparatorChar}customer_search_api_consumer-customer_search_api.json")
                    .Verify();
            }
        }

        public virtual void Dispose()
        {
        }
    }
}
