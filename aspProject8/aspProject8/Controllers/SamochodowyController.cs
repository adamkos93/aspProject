using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspProjekt8.Models;
using aspProjekt2.DAL;

namespace aspProject8.Controllers
{
    public class SamochodowyController : Controller
    {
        private WarsztatContext db = new WarsztatContext();

        // GET: /Samochodowy/
        //public ActionResult Index()
        //{
        //    var cars = db.Cars.Include(c => c.klient).Include(c => c.worker);
        //    return View(cars.ToList());
        //}
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var car = from c in db.Cars
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(s => s.Model.Contains(searchString)
                                       || s.Silnik.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    car = car.OrderByDescending(s => s.Model);
                    break;
                case "Date":
                    car = car.OrderBy(s => s.DoOddania);
                    break;
                case "date_desc":
                    car = car.OrderByDescending(s => s.DoOddania);
                    break;
                default:
                    car = car.OrderBy(s => s.Model);
                    break;
            }

            return View(car.ToList());
        }

        // GET: /Samochodowy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: /Samochodowy/Create
        public ActionResult Create()
        {
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "ImieNazwiskoKlienta");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "ImieNazwiskoPracownika");
            return View();
        }

        // POST: /Samochodowy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Model,Rocznik,Silnik,Skrzynia,Moc,Pojemność,Przebieg,DodatkoweInformacje,DoOddania,WorkerID,KlientID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlientID = new SelectList(db.Klients, "ID", "ImieNazwiskoKlienta", car.KlientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "ImieNazwiskoPracownika", car.WorkerID);
            return View(car);
        }

        // GET: /Samochodowy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "ImieNazwiskoKlienta", car.KlientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "ImieNazwiskoPracownika", car.WorkerID);
            return View(car);
        }

        // POST: /Samochodowy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Model,Rocznik,Silnik,Skrzynia,Moc,Pojemność,Przebieg,DodatkoweInformacje,DoOddania,WorkerID,KlientID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlientID = new SelectList(db.Klients, "ID", "ImieNazwiskoKlienta", car.KlientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "ImieNazwiskoPracownika", car.WorkerID);
            return View(car);
        }

        // GET: /Samochodowy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: /Samochodowy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
