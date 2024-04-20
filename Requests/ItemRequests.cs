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

            app.MapGet("/items/{id}", (HHPWDbContext db, int id) =>
            {
                var item = db.Items.SingleOrDefault(i => i.Id == id);

                if (item == null) return Results.NotFound();

                return Results.Ok(item);
            });
        }
    }
}
