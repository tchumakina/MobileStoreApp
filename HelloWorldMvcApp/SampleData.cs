using System.Linq;
using MobileStore.Models;

namespace MobileStore
{
    public static class SampleData
    {
        public static void Initialize(IDbContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600,
                        ReleaseYear = 2019
                    },
                    new Phone
                    {
                        Name = "Galaxy Edge",
                        Company = "Samsung",
                        Price = 550,
                        ReleaseYear = 2016
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500,
                        ReleaseYear = 2018
                    },
                    new Phone
                    {
                        Name = "MicroTAC",
                        Company = "Motorola",
                        Price = 5,
                        ReleaseYear = 1989
                    }
                );
                context.SaveChanges();
            }
        }
    }
}