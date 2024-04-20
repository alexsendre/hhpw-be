namespace hhpw_be.Requests
{
    public class OrderTypeRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orderTypes", (HHPWDbContext db) =>
            {
                return db.OrderTypes.ToList();
            });
        }
    }
}
