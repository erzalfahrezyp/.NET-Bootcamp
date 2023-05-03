// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

List<Product> products = new List<Product>();
products.Add(new Product { Id = 1, Name = "Product 1", Stock = 10 });
products.Add(new Product { Id = 2, Name = "Product 2", Stock = 20 });
products.Add(new Product { Id = 3, Name = "Product 3", Stock = 30 });
products.Add(new Product { Id = 4, Name = "Product 4", Stock = 40 });
products.Add(new Product { Id = 5, Name = "Product 5", Stock = 50 });
products.Add(new Product { Id = 6, Name = "Product 6", Stock = 60 });

// LINQ
// Select
var hasil = products.Select(x => x.Name);

// filter
var hasil2 = products.Where(x => x.Stock > 30 || x.Stock < 50);

// sql
// select * from products where stock > 30 or stock < 50
var hasil3 = from p in products
             where p.Stock > 30 || p.Stock < 50
             select p;

Console.WriteLine(hasil3);