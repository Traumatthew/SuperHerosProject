using SuperHerosProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHerosProject.Controllers
{
    public class SuperherosController : Controller
    {
        ApplicationDbContext db;

        public SuperherosController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Superheros
        public ActionResult Index()
        {
            var superheros = db.Superheroes.ToList();
            return View(superheros);
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            //Superheros superhero = new Superheros();
            //return View(superhero);
            //ViewBag.superhero = new Superheros(db.Superheroes, "Name", "AlterEgo", "PrimaryAblity", "SecondaryAbility", "Catchphrase");
            return View();
        }

        // POST: Superheros/Create
        [HttpPost]
        public ActionResult Create(Superheros superhero)
        {
            db.Superheroes.Add(superhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Superhero/Delete
        public ActionResult Delete()
        {
            //Superheros superhero = new Superheros();
            //return View(superhero);
            var superheros = db.Superheroes.ToList();
            return View(superheros);
        }

        //POST: Superheros/Delete
        [HttpPost]
        public ActionResult Delete(Superheros superhero)
        {
            db.Superheroes.Remove(superhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}