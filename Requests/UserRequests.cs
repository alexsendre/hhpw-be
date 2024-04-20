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

            app.MapGet("/checkuser/{uid}", (HHPWDbContext db, string uid) =>
            {
                var validUser = db.Users.Where(u => u.Uid == uid).ToList();
                if (validUser == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(validUser);
            });
        }
    }
}
