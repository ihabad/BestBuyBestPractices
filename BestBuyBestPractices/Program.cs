using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var dRepo = new DapperDepartmentRepository(conn);

var departments = dRepo.GetAll();

foreach (var item
    in departments)
{
    Console.WriteLine(item.DepartmentID);
    Console.WriteLine(item.Name);
}

//Ex 2

var productRepository = new DapperProductRepository(conn);

var productToUpdate = productRepository.GetProduct(56);
productRepository.UpdateProduct(productToUpdate);

var products = productRepository.GetAllProducts();

foreach (var item in products)
{
    Console.WriteLine(item.ProductId);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.OnSale);
    Console.WriteLine(item.price);
    Console.WriteLine(item.CategoryId);
    Console.WriteLine(item.stockLevel);
}