using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Provider.Api.Web.Models;
using ServiceProvider.Models;

namespace ServiceProvider.Database
{
    public static class ExampleData
    {
        private static readonly Product P1 = new Product()
        {
            balance = 64.99m,
            interestRate = 20m,
            name = "Raspberry Pi 4 Model B 4GB",
            productCode = "LEIWAND999"
        };
        private static readonly Product P2 = new Product()
        {
            balance = 25.99m,
            interestRate = 30m,
            name = "RPI4 Case",
            productCode = "EHSICHER123"
        };
        private static readonly Product P3 = new Product()
        {
            balance = 413.20m,
            interestRate = 10m,
            name = "Baum im Wald",
            productCode = "UMFALLT222"
        };

        private static readonly Customer C1 = new Customer()
        {
            name = "Arthur Koenig",
            address = "Hier und Da 22",
            dateOfBirth = new DateTime(1950,5,6),
            emailAddress = "arthur.koenig@schwertstein.at",
            financialProducts = new List<Product>() { P1,P2,P3},
            status = "Royal"
        };
        private static readonly Customer C2 = new Customer()
        {
            name = "Merlin Magyerhofer",
            address = "Immer wieder nie 45",
            dateOfBirth = new DateTime(1900, 11, 14),
            emailAddress = "merlin.magyer@schwertstein.at",
            financialProducts = new List<Product>() { P2 },
            status = "Gold"
        };
        private static readonly Customer C3 = new Customer()
        {
            name = "Harry Potter",
            address = "4 Privet Drive, Little Whinging, Surrey",
            dateOfBirth = new DateTime(1989, 7, 23),
            emailAddress = "harry.potter@wronguniverse.at",
            financialProducts = new List<Product>(),
            status = "Stone of Wisdom"
        };

        public static List<Customer> AllCustomers { get; } = new List<Customer>() { C1, C2, C3 };
    }
}
