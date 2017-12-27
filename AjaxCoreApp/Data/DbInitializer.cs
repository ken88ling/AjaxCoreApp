using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AjaxCoreApp.Models;

namespace AjaxCoreApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            Category category1 = null;
            Category category2 = null;

            if (!context.Categories.Any())
            {
                category1 = new Category()
                {
                    CategoryName = "Keyboard"
                };
                category2 = new Category()
                {
                    CategoryName = "Mouse"
                };

                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (category1 != null)
                    {
                        var product = new Product()
                        {
                            CategoryId = category1.CategoryId,
                            ProductName = "Logistech " + i,
                            Price = 1000 + i
                        };
                        context.Products.Add(product);
                    }
                }
                for (int i = 0; i < 1000; i++)
                {
                    if (category2 != null)
                    {
                        var product = new Product()
                        {
                            CategoryId = category2.CategoryId,
                            ProductName = "HP " + i,
                            Price = 2000 + i
                        };
                        context.Products.Add(product);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
