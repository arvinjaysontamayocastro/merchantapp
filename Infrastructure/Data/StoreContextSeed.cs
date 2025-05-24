using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            if (products == null) return;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        }
        if (!context.UserIdentities.Any())
        {
            var identitiesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/identities.json");

            var identities = JsonSerializer.Deserialize<List<UserIdentity>>(identitiesData);

            if (identities == null) return;

            context.UserIdentities.AddRange(identities);

            await context.SaveChangesAsync();
        }
    }
}
