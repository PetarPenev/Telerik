namespace _03.Model.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _02.Model.Classes;

    public sealed class Configuration : DbMigrationsConfiguration<_03.Model.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_03.Model.Data.Context context)
        {
            CardAccount firstAccount = new CardAccount();
            firstAccount.CardCash = 50m;
            firstAccount.CardNumber = "1111111111";
            firstAccount.CardPin = "1111";

            CardAccount secondAccount = new CardAccount();
            secondAccount.CardCash = 150m;
            secondAccount.CardNumber = "3333333333";
            secondAccount.CardPin = "3333";

            context.CardAccounts.AddOrUpdate(p => p.CardNumber, firstAccount);
            context.CardAccounts.AddOrUpdate(p => p.CardNumber, secondAccount);
        }
    }
}
