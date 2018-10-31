using System;

namespace Application.Persistence
{
    public class AppDbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbInitializer();
            initializer.Seed(context);
        }

        public void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // TODO
        }
    }
}
