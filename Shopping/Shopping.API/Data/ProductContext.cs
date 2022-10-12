using System;
using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            var existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone X",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile = "prodcut-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samasung 10",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile="product-2.png",
                    Price=840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile="product-3.png",
                    Price=650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile="product-4.png",
                    Price=470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "WTC U11+ Plus",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile="product-5.png",
                    Price=380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ New8",
                    Description = "This phone is the company's bigget change to its flagship smartphone in years. It inclues a borderless.",
                    ImageFile="product-6.png",
                    Price=240.00M,
                    Category = "Home Kitchen"
                }
            };
        }
    }
}

