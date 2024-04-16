namespace hhpw_be.Requests
{
    public class ItemRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/items", (HHPWDbContext db) =>
            {
                return db.Items.ToList();
            });
        }
    }
}
