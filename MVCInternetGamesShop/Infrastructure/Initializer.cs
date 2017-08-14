using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Infrastructure
{
    public class Initializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SeedData(context);
            base.Seed(context);
        }

        private void SeedData(ApplicationDbContext context)
        {
            var games = new List<Game>
            {
                new Game () {Name="Tomb Raider", PlatformId = 1, Price = 200, IsBestseller = false, Description = "Gra z Larą Croft na PS4", ImageName="RiseOfTheTombRider.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Tomb Raider", PlatformId = 2, Price = 220, IsBestseller = false, Description = "Gra z Larą Croft na PC", ImageName="TombRaider.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Tomb Raider", PlatformId = 3, Price = 230, IsBestseller = false, Description = "Gra z Larą Croft na XBOX", ImageName="TombRaiderXBOX.jpg", ReleaseDate= new DateTime(2017, 07, 31) },
                new Game () {Name="Horizon Zero Dawn", PlatformId = 1, Price = 240, IsBestseller = true, Description = "Gra Horizon Zero Dawn na PS4", ImageName="HorizonZeroDawn.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="FEAR", PlatformId = 2, Price = 140, IsBestseller = true, Description = "Gra FEAR na PC", ImageName="FEAR.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Gears Of War", PlatformId = 3, Price = 100, IsBestseller = true, Description = "Gra Gears of War na XBOX", ImageName="GearsOfWar.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="BloodBorne", PlatformId = 1, Price = 270, IsBestseller = true, Description = "Gra BloodBorne na PS4", ImageName="BloodBorne.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="The Sims 4", PlatformId = 2, Price = 216, IsBestseller = true, Description = "Gra The Sims 4 na PC", ImageName="The sims 4.jpg", ReleaseDate= new DateTime(2017, 11, 11) },
                new Game () {Name="Mafia III", PlatformId = 3, Price = 244, IsBestseller = true, Description = "Gra Mafia III na XBOX", ImageName="Mafia III.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Life is strange", PlatformId = 1, Price = 254, IsBestseller = true, Description = "Gra Life is Strange na PS4", ImageName="LifeIsStrange.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Life is strange", PlatformId = 2, Price = 255, IsBestseller = true, Description = "Gra Life is Strange na PC", ImageName="LifeIsStrange.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Life is strange", PlatformId = 3, Price = 256, IsBestseller = true, Description = "Gra Life is Strange na XBOX", ImageName="LifeIsStrange.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="The Last of Us", PlatformId = 1, Price = 276, IsBestseller = true, Description = "Gra the Last of Us na PS4", ImageName="TheLastOfUs.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Redeemer", PlatformId = 2, Price = 106, IsBestseller = true, Description = "Redeemer na PC", ImageName="Redeemer.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Killer Instinct", PlatformId = 3, Price = 136, IsBestseller = true, Description = "Killer Instinct na XBOX", ImageName="killerInstinct.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Yesterday Origins", PlatformId = 1, Price = 236, IsBestseller = false, Description = "Yesterday Origins na PS4", ImageName="YesterdayOrigins.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Yesterday Origins", PlatformId = 2, Price = 216, IsBestseller = false, Description = "Yesterday Origins na PC", ImageName="YesterdayOrigins.jpg", ReleaseDate= new DateTime(2015, 11, 11) },
                new Game () {Name="Yesterday Origins", PlatformId = 3, Price = 266, IsBestseller = false, Description = "Yesterday Origins na XBOX", ImageName="YesterdayOrigins.jpg", ReleaseDate= new DateTime(2015, 11, 11) },


            };
            foreach (Game game in games)
            {
                context.Games.Add(game);
                context.SaveChanges();                
            }
        }
    }
}