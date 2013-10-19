namespace _02.Data.Migrations
{
    using _01.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_02.Data.WorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_02.Data.WorldContext context)
        {
            var continent = new Continent();
            continent.Name = "Asia";

            var c1 = new Country();
            c1.Name = "Turkey";
            c1.Language = "Turkish";
            c1.Population = 1111;

            var c1t1 = new Town();
            c1t1.Name = "Istanbul";
            c1t1.Population = 10000000;
            c1.Towns.Add(c1t1);

            var c1t2 = new Town();
            c1t2.Name = "Ankara";
            c1t2.Population = 20000000;
            c1.Towns.Add(c1t2);

            var c2 = new Country();
            c2.Name = "China";
            c2.Language = "Mandarin";
            c2.Population = 1500000000;

            var c2t1 = new Town();
            c2t1.Name = "Beijing";
            c2t1.Population = 25000000;
            c2.Towns.Add(c2t1);

            continent.Countries.Add(c1);
            continent.Countries.Add(c2);

            context.Continents.AddOrUpdate(c => c.Name, continent);

            var secondContinent = new Continent();
            secondContinent.Name = "Europe";

            var country1 = new Country();
            country1.Name = "Austria";
            country1.Language = "German";
            country1.Population = 10000000;

            var country1town = new Town();
            country1town.Name = "Vienna";
            country1town.Population = 2000000;
            country1.Towns.Add(country1town);

            var country2 = new Country();
            country2.Name = "Germany";
            country2.Language = "German";
            country2.Population = 80000000;

            var country2town = new Town();
            country2town.Name = "Berlin";
            country2town.Population = 5000000;
            country2.Towns.Add(country2town);

            var country3 = new Country();
            country3.Name = "Bulgaria";
            country3.Language = "Bulgarian";
            country3.Population = 7000000;

            var country3town1 = new Town();
            country3town1.Name = "Sofia";
            country3town1.Population = 2000000;
            country3.Towns.Add(country3town1);

            var country3town2 = new Town();
            country3town2.Name = "Plovdiv";
            country3town2.Population = 400000;
            country3.Towns.Add(country3town2);

            var country3town3 = new Town();
            country3town3.Name = "Varna";
            country3town3.Population = 300000;
            country3.Towns.Add(country3town3);

            var country3town4 = new Town();
            country3town4.Name = "Burgas";
            country3town4.Population = 200000;
            country3.Towns.Add(country3town4);

            var country4 = new Country();
            country4.Name = "England";
            country4.Language = "English";
            country4.Population = 70000000;

            var country4town = new Town();
            country4town.Name = "London";
            country4town.Population = 10000000;
            country4.Towns.Add(country4town);

            secondContinent.Countries.Add(country1);
            secondContinent.Countries.Add(country2);
            secondContinent.Countries.Add(country3);
            secondContinent.Countries.Add(country4);
            context.Continents.AddOrUpdate(c => c.Name, secondContinent);
        }
    }
}
