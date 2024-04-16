namespace hhpw_be.Requests
{
    public class UserRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users", (HHPWDbContext db) =>
            {
                return db.Users.ToList();
            });
        }
    }
}
