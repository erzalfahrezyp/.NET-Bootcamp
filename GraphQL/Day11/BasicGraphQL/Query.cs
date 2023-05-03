using BasicGraphQL.Models;

public class Query
{
    //public readonly AdventureWorks2019Context _context;
    //public Query(AdventureWorks2019Context context)
    //{
    //    _context = context;
    //}
    
    public IQueryable<Employee> GetEmployees([Service]AdventureWorks2019Context context) => context.Employees;

    //public List<Employee> GetEmployees() => _context.Employees.ToList();
    public string GetHello()
    {
        return "Hello World";
    }
    public string GetMessage() => "Hello World";

    //public Product GetProduct()
    //{
    //    return new Product{ Id = 1, Name = "Product 1", Price = 2.5f };
    //}
    //public List<Product> GetProducts()
    //{
    //    var list = new List<Product>();
    //    list.Add(new Product { Id = 1, Name = "Product 1", Price = 2.5f });
    //    list.Add(new Product { Id = 2, Name = "Product 2", Price = 3.5f });
    //    list.Add(new Product { Id = 3, Name = "Product 3", Price = 4.5f });

    //    return list;
    //}
}
