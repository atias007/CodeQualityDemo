using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Dapper.Contrib.Extensions;
using EntityFrameworkDemo.Dto;
using EntityFrameworkDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    internal class Program
    {
        // *** database script: https://raw.githubusercontent.com/microsoft/sql-server-samples/master/samples/databases/northwind-pubs/instnwnd%20(Azure%20SQL%20Database).sql

        // *** Learn EF Core: https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

        // *** Learn Dapper: https://www.learndapper.com/selecting-single-rows

        private static async Task Main(string[] args)
        {
            using var context = new NorthwindContext("Buenos Aires");

            ///var customers = await context.Customers.ToListAsync();
            //var customers = await context.Customers.IgnoreQueryFilters().ToListAsync();

            for (int i = 0; i < 300; i++)
            {
                var hilo = new HiLoDemo { Title = "Title" };
                context.HiLoDemos.Add(hilo);

                hilo.Title += $" {hilo.Id}";
            }

            //var conn = context.Database.GetDbConnection();

            ////conn.Insert(new HiLoDemo { Title = "Title" });

            await context.SaveChangesAsync();

            // https://github.com/DapperLib/Dapper.Contrib

            var configuration = new MapperConfiguration(cfg =>
               cfg.CreateProjection<Category, CategotyDto>());
            context.Set<Category>().ProjectTo<CategotyDto>(configuration).ToList();

            Pause();

            context.Set<Category>().ToList();

            Pause();

            var category = await
                context.Categories
                .Where(c => c.CategoryId == 1)
                .Select(c => c.Description)
                .FirstOrDefaultAsync();

            Console.WriteLine(category);

            Pause();

            ////using (var conn = new SqlConnection(@"Password=CustomsDev123!;Persist Security Info=True;User ID=sa;Initial Catalog=Northwind;Data Source=localhost"))
            ////{
            ////    var allCategories = await conn.QueryAsync<Category>("SELECT CategoryId, Description FROM Categories");
            ////    foreach (var item in allCategories)
            ////    {
            ////        Console.WriteLine($"{item.CategoryId} - {item.Description}");
            ////    }
            ////}

            Pause();

            var newCategory = new Category
            {
                CategoryName = "TestDemo",
                Description = "Category Description TestDemo",
                Picture = null
            };

            context.Categories.Add(newCategory);
            // var result = await context.Categories.AddAsync(newCategory);

            var effectedRows = context.SaveChanges();
            Console.WriteLine($"{effectedRows} row(s) effectged. CategoryID = {newCategory.CategoryId}");

            Pause();

            context.Dispose();
            //context = new NorthwindContext();

            var deletedCategoty = new Category { CategoryId = newCategory.CategoryId };
            context.Categories.Remove(deletedCategoty);
            effectedRows = context.SaveChanges();
            Console.WriteLine($"{effectedRows} row(s) effectged");

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine(" === Press enter to continue ===");
            Console.ReadLine();
        }
    }
}