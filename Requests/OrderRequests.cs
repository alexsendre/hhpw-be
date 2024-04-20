using hhpw_be.DTOs;
using hhpw_be.Models;
using Microsoft.EntityFrameworkCore;

namespace hhpw_be.Requests
{
    public class OrderRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders/all", (HHPWDbContext db) =>
            {
                return db.Orders.ToList();
            });

            app.MapGet("/orders/{id}", (HHPWDbContext db, int id) =>
            {
                var order = db.Orders.Include(o => o.Items).Include(o => o.OrderTypes).SingleOrDefault(o => o.Id == id);

                if (order == null)
                {
                    return Results.NotFound("Unable to find requested data");
                }

                var response = new
                {
                    id = order.Id,
                    name = order.CustomerName,
                    status = order.IsClosed,
                    phone = order.CustomerPhone,
                    email = order.CustomerEmail,
                    type = order.OrderTypes.Select(type => new
                    {
                        id = type.Id,
                        name = type.Name,
                    }),
                    items = order.Items.Select(item => new
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                    }),
                };

                return Results.Ok(response);
            });

            app.MapGet("/orders/{orderId}/items", (HHPWDbContext db, int orderId) =>
            {
                var order = db.Orders.Include(o => o.Items).SingleOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var response = new
                {
                    items = order.Items.Select(item => new
                    {
                        id = item.Id,
                        name = item.Name,
                        price = item.Price,
                    })
                };

                return Results.Ok(response);
            });

            app.MapPost("/orders/new", (HHPWDbContext db, Order newOrder) =>
            {
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });

            app.MapDelete("/orders/{id}", (HHPWDbContext db, int id) =>
            {
                var order = db.Orders.SingleOrDefault(o => o.Id == id);

                if (order == null)
                {
                    return Results.NotFound();
                }

                db.Orders.Remove(order);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPut("/orders/edit/{orderId}", (HHPWDbContext db, int orderId, Order newOrder) =>
            {
                var orderToUpdate = db.Orders.SingleOrDefault(o => o.Id == orderId);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                orderToUpdate.CustomerName = newOrder.CustomerName;
                orderToUpdate.CustomerEmail = newOrder.CustomerEmail;
                orderToUpdate.CustomerPhone = newOrder.CustomerPhone;
                orderToUpdate.OrderTypeId = newOrder.OrderTypeId;

                db.SaveChanges();
                return Results.Ok(orderToUpdate) ;
            });

            // add item to cart
            app.MapPost("/orders/{orderId}/add", (HHPWDbContext db, AddToCartDTO newItem) =>
            {
                var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == newItem.OrderId);
                var itemToAdd = db.Items.Find(newItem.ItemId);

                if (order == null || itemToAdd == null)
                {
                    return Results.NotFound();
                }

                try
                {
                    order.Items.Add(itemToAdd);
                    db.SaveChanges();
                    return Results.Created($"/orders/{newItem.OrderId}/items/{newItem.ItemId}", itemToAdd);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            // remove item from cart
            app.MapDelete("/orders/{orderId}/items/{itemId}", (HHPWDbContext db, int orderId, int itemId) =>
            {
                var order = db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == orderId);
                var item = db.Items.Find(itemId);

                if (order == null || item == null)
                {
                    return Results.NotFound("Invalid data request");
                }

                order.Items.Remove(item);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
