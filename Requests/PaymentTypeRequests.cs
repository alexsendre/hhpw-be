namespace hhpw_be.Requests
{
    public class PaymentTypeRequests
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/paymentTypes", (HHPWDbContext db) =>
            {
                return db.PaymentTypes.ToList();
            });
        }
    }
}
