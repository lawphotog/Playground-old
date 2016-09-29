namespace ProductsAPI.Migrations
{
    using ProductsAPI.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsAPI.Models.ProductsAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductsAPI.Models.ProductsAPIContext context)
        {
            context.Categories.AddOrUpdate(
                    c => c.Name,
                    new Category { Name = "cameras" },
                    new Category { Name = "phones" },
                    new Category { Name = "computers" }
                );

            context.Products.AddOrUpdate(
                    p => p.Name,
                    new Product { Name = "Nikon D800", Description = GetDescription(), CategoryId = 1 },
                    new Product { Name = "Canon 5D Mark III", Description = GetDescription(), CategoryId = 1 },
                    new Product { Name = "Canon 1DX", Description = GetDescription(), CategoryId = 1 },
                    new Product { Name = "Nikon D4s", Description = GetDescription(), CategoryId = 1 },
                    new Product { Name = "iPhone 6 64gb", Description = GetDescription(), CategoryId = 2 },
                    new Product { Name = "iPhone 6 Plus 64gb", Description = GetDescription(), CategoryId = 2 },
                    new Product { Name = "Samsung Galaxy S6 Edge", Description = GetDescription(), CategoryId = 2 },
                    new Product { Name = "Xiaomi Mi4", Description = GetDescription(), CategoryId = 2 },
                    new Product { Name = "Macbook pro 13", Description = GetDescription(), CategoryId = 3 },
                    new Product { Name = "Macbook pro 15", Description = GetDescription(), CategoryId = 3 },
                    new Product { Name = "Dell XPS 15", Description = GetDescription(), CategoryId = 3 },
                    new Product { Name = "Razer Blade Pro", Description = GetDescription(), CategoryId = 3 }
                );
        }

        private string GetDescription()
        {
            return "this is description this is description this is description this is description this is description this is description this is description";
        }
    }
}
