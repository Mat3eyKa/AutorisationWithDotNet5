namespace IdentityAutorisationWithDotNet5.Data
{
    public class DbInitialize
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
