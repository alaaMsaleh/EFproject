using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject
{
   public class Orderservice
    {
        public void CreateOrder(Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                
                context.Orders.Add(order);
                context.SaveChanges();
            }

        }

        public Order GetOrderById(int orderId) 
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Orders.Find(orderId);
            }
        
        
        }
        public IQueryable<Order> GetAllOrders()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Orders.Include(o => o.Customer);
            }

             void UpdateOrder(int orderId, DateTime newOrderDate, int newCustomerId)
            {
                using (var context = new ApplicationDbContext())
                {
                    var order = context.Orders.Find(orderId);
                    if (order != null)
                    {
                        order.orderDate = newOrderDate;
                        order.CustomerId = newCustomerId;
                        context.SaveChanges();
                    }
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var context = new ApplicationDbContext())
            {
                var order = context.Orders.Find(orderId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }

        public void SeedData()
        {
            using (var context = new ApplicationDbContext())
            {
               
                context.Database.EnsureCreated();

                
                var alaa = new Customer { Name = "alaa", Email = "alaa@example.com", PhoneNumber = "1234567890" };
                var bob = new Customer { Name = "Bob", Email = "bob@example.com" };
                var aseel = new Customer { Name = "aseel", Email = "aseel@example.com", PhoneNumber = "0987654321" };

                context.Customers.AddRange(alaa, bob, aseel);
                context.SaveChanges();

            
                var laptop = new Product { Name = "Laptop", Price = 999.99m, Description = "High performance laptop" };
                var smartphone = new Product { Name = "Smartphone", Price = 499.99m, Description = "Latest model smartphone" };
                var headphones = new Product { Name = "Headphones", Price = 199.99m };

                context.Products.AddRange(laptop, smartphone, headphones);
                context.SaveChanges();

                // Add orders
                context.Orders.AddRange(
                    new Order { orderDate = DateTime.Now, CustomerId = alaa.Id },
                    new Order { orderDate = DateTime.Now, CustomerId = bob.Id },
                    new Order { orderDate = DateTime.Now, CustomerId = aseel.Id },
                    new Order { orderDate = DateTime.Now, CustomerId = aseel.Id },
                    new Order { orderDate = DateTime.Now, CustomerId = bob.Id }
                );
                context.SaveChanges();
            }
        }




    }
}
