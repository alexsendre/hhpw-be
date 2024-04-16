namespace hhpw_be.Requests
{
    public class OrderRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders", (HHPWDbContext db) =>
            {
                return db.Orders.ToList();
            });
        }
    }
}
