﻿using System;
using System.IO;
using PactNet;
using PactNet.Mocks.MockHttpService;
using PactNet.Models;

namespace Customer_Search_ConsumerTests
{
    public class ConsumerEventApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; }
        public IMockProviderService MockProviderService { get; }

        public int MockServerPort => 9222;
        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}";

        public ConsumerEventApiPact()
        {
            PactBuilder = new PactBuilder(new PactConfig
            {
                SpecificationVersion = "2.0.0",
                LogDir = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}logs{Path.DirectorySeparatorChar}",
                PactDir = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}pacts{Path.DirectorySeparatorChar}"
            })
                .ServiceConsumer("Customer Search API Consumer")
                .HasPactWith("Customer Search API");

            MockProviderService = PactBuilder.MockService(MockServerPort, false, IPAddress.Any);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}