namespace _02.ChatCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_02.ChatCodeFirst.ChatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_02.ChatCodeFirst.ChatContext context)
        {
            for (int i = 0; i < 200; i++)
            {
                var message = new Message();
                message.MessageText = "This is message number " + i;
                message.Date = DateTime.Now;
                context.Messages.AddOrUpdate(m => m.MessageText, message);
                context.SaveChanges();
            }
        }
    }
}
