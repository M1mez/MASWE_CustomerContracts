using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceProvider.Models;

namespace ServiceProvider.Database
{
    public static class ExampleData
    {
        private static readonly Product P1 = new Product()
        {
            Balance = 64.99m,
            InterestRate = 20m,
            Name = "Raspberry Pi 4 Model B 4GB",
            ProductCode = "LEIWAND999"
        };
        private static readonly Product P2 = new Product()
        {
            Balance = 25.99m,
            InterestRate = 30m,
            Name = "RPI4 Case",
            ProductCode = "EHSICHER123"
        };
        private static readonly Product P3 = new Product()
        {
            Balance = 413.20m,
            InterestRate = 10m,
            Name = "Baum im Wald",
            ProductCode = "UMFALLT222"
        };

        private static readonly Customer C1 = new Customer()
        {
            Name = "Arthur König",
            Address = "Hier und Da 22",
            DateOfBirth = new DateTime(1950,5,6),
            EmailAddress = "arthur.koenig@schwertstein.at",
            FinancialProducts = new List<Product>() { P1,P2,P3},
            Status = "Royal"
        };
        private static readonly Customer C2 = new Customer()
        {
            Name = "Merlin Magyerhofer",
            Address = "Immer wieder nie 45",
            DateOfBirth = new DateTime(1900, 11, 14),
            EmailAddress = "merlin.magyer@schwertstein.at",
            FinancialProducts = new List<Product>() { P2 },
            Status = "Gold"
        };
        private static readonly Customer C3 = new Customer()
        {
            Name = "Harry Potter",
            Address = "4 Privet Drive, Little Whinging, Surrey",
            DateOfBirth = new DateTime(1989, 7, 23),
            EmailAddress = "harry.potter@wronguniverse.at",
            FinancialProducts = new List<Product>(),
            Status = "Stone of Wisdom"
        };

        public static List<Customer> AllCustomers { get; } = new List<Customer>() { C1, C2, C3 };
    }
}
