using System;
using System.Collections.Generic;
using System.Linq;
using Customer_Search_Consumer;
using Customer_Search_Consumer.Models;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Customer_Search_ConsumerTests
{
    public class EventsApiConsumerTests : IClassFixture<ConsumerEventApiPact>
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _mockProviderServiceBaseUri;

        public EventsApiConsumerTests(ConsumerEventApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
            _mockProviderService.ClearInteractions();
        }

        [Fact]
        public void GetAllCustomersStatus_ReturnsAllCustomersWithStatus()
        {

            //Arrange
            _mockProviderService
                .Given("there is a Customer with Name ")
                .UponReceiving("a request for Customer with Name and Financial Products ")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/customerSearch",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    },
                    Body = 
                        new Customer
                        {
                            name = "Arthur Koenig",
                            address = "Hier und Da 22",
                            dateOfBirth = new DateTime(1950, 5, 6),
                            emailAddress = "arthur.koenig@schwertstein.at",
                            financialProducts = new List<Product>()
                            {
                                new Product()
                                {
                                    balance = 64.99m,
                                    interestRate = 20m,
                                    name = "Raspberry Pi 4 Model B 4GB",
                                    productCode = "LEIWAND999"
                                },
                                new Product()
                                {
                                    balance = 25.99m,
                                    interestRate = 30m,
                                    name = "RPI4 Case",
                                    productCode = "EHSICHER123"
                                },
                                new Product()
                                {
                                    balance = 413.20m,
                                    interestRate = 10m,
                                    name = "Baum im Wald",
                                    productCode = "UMFALLT222"
                                },

                            },
                            status = "Royal"
                        }

                });

            var consumer = new EventsApiClient(_mockProviderServiceBaseUri);
            var consumerName = "Arthur Koenig";

            //Act
            var result = consumer.CustomerSearch(consumerName);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Customer>(result);
            Assert.Equal(consumerName, result.name);

            _mockProviderService.VerifyInteractions();
        }
    }
}
