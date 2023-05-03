using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDbAppMinimal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service db
string db = builder.Configuration.GetConnectionString("MyDB");
builder.Services.AddDbContext<BootcampContext>(o => o.UseSqlServer(db));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// api
// CRUD
// create
app.MapPost("/product", (BootcampContext context, [FromBody] Product p) =>
{
    // insert
    context.Products.Add(p);
    context.SaveChanges(); // commit db

    return p;
});
// read
app.MapGet("/product", (BootcampContext context) =>
{
    return context.Products;
});
// details
app.MapGet("/product/(id)", (BootcampContext context, int id) =>
{
    // get product by id
    var product = context.Products.Where(o => o.Id == id).FirstOrDefault();
    return product;
});
// edit
app.MapPut("/product/(id)", (BootcampContext context, int id, [FromBody] Product p) =>
{
    // get product by id
    var product = context.Products.Where(o => o.Id == id).FirstOrDefault();
    if (product != null)
    {
        // update
        if (!string.IsNullOrEmpty(p.Name))
            product.Name = p.Name;
        product.Price = p.Price;
        product.Stock = p.Stock;

        // save
        context.Products.Update(product);
        context.SaveChanges();
    }
       
    return product;
});
// delete
app.MapDelete("/product/(id)", (BootcampContext context, int id) =>
{
    // get product by id
    var product = context.Products.Where(o => o.Id == id).FirstOrDefault();
    if(product != null)
    {
        // delete
        context.Products.Remove(product);
        context.SaveChanges();
    }

    return product;
});

app.Run();