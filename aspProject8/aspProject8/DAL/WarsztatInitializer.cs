using aspProjekt8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspProjekt2.DAL
{
    public class WarsztatInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WarsztatContext>
    {
        protected override void Seed(WarsztatContext context)
        {

            var pracownicy = new List<Worker>{
                new Worker{ImieNazwiskoPracownika="Jan Kowalski"},
                new Worker{ImieNazwiskoPracownika="Zbyszek Wiejski"}
            };
            pracownicy.ForEach(p => context.Workers.Add(p));
            context.SaveChanges();

            Dictionary<string, int> listapracownikow = new Dictionary<string, int>();
            context.Workers.ToList().ForEach(t => listapracownikow.Add(t.ImieNazwiskoPracownika, t.ID));

            var klienci = new List<Klient>{
                new Klient{ImieNazwiskoKlienta="Hubert Pietruczuk",Email="hpietruczuk@gmail.com"},
                new Klient{ImieNazwiskoKlienta="Aleksandra Ostaszewska",Email="aleksandraostaszewska@gmail.com"}
            };
            klienci.ForEach(k => context.Klients.Add(k));
            context.SaveChanges();

            Dictionary<string, int> listaklientow = new Dictionary<string, int>();
            context.Klients.ToList().ForEach(t => listaklientow.Add(t.ImieNazwiskoKlienta, t.ID));

            var samochodziki = new List<Car>{
                new Car{Model="XJ",Rocznik=2000,Silnik="benzynowy",Skrzynia="automatyczna",Moc=200,Pojemność=4.5,Przebieg=200000,DodatkoweInformacje="Uszkodzony przedni zderzak",DoOddania=DateTime.Parse("2015-02-30"),WorkerID=listapracownikow["Jan Kowalski"],KlientID=listaklientow["Hubert Pietruczuk"]},
                 new Car{Model="XK",Rocznik=2001,Silnik="benzynowy",Skrzynia="automatyczna",Moc=200,Pojemność=4.5,Przebieg=200000,DodatkoweInformacje="Uszkodzony tylny zderzak",DoOddania=DateTime.Parse("2015-02-15"),WorkerID=listapracownikow["Zbyszek Wiejski"],KlientID=listaklientow["Aleksandra Ostaszewska"]}
            
            };
            samochodziki.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();

        }
    }
}