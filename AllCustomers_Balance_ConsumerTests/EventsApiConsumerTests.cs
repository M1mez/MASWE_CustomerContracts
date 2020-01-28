using System;
using System.Collections.Generic;
using System.Linq;
using AllCustomers_Balance_Consumer;
using AllCustomers_Balance_Consumer.Models;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace AllCustomers_Balance_ConsumerTests
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
        public void GetAllCustomersBalance_ReturnsAllCustomersWithBalance()
        {

            //Arrange
            _mockProviderService
                .Given("there are Customers with Balance ")
                .UponReceiving("a request for all Customers with Balance ")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/allCustomersBalance",
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
                    Body = new List<BalanceCustomer>
                    {
                        new BalanceCustomer(
                        new Customer
                        {
                            name = "Arthur Koenig",
                            address = "Hier und Da 22",
                            dateOfBirth = new DateTime(1950,5,6),
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
                        }),
                        new BalanceCustomer(
                        new Customer
                        {
                            name = "Merlin Magyerhofer",
                            address = "Immer wieder nie 45",
                            dateOfBirth = new DateTime(1900, 11, 14),
                            emailAddress = "merlin.magyer@schwertstein.at",
                            financialProducts = new List<Product>() { new Product(){
                                balance = 25.99m,
                                interestRate = 30m,
                                name = "RPI4 Case",
                                productCode = "EHSICHER123"} },
                            status = "Gold"
                        }),
                        new BalanceCustomer(
                        new Customer
                        {
                            name = "Harry Potter",
                            address = "4 Privet Drive, Little Whinging, Surrey",
                            dateOfBirth = new DateTime(1989, 7, 23),
                            emailAddress = "harry.potter@wronguniverse.at",
                            financialProducts = new List<Product>(),
                            status = "Stone of Wisdom"
                        })
                    }
                });

            var consumer = new EventsApiClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.AllCustomersBalance();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());

            _mockProviderService.VerifyInteractions();
        }
    }
}
