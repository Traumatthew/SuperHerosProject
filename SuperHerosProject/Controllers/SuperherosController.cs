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
       ApplicationDbContext db = new ApplicationDbContext();

        //============================================================================================

        // GET: Superheros
        public ActionResult Index()
        {
            List<Superheros> superheros = new List<Superheros>();
            
            superheros = db.Superheros.ToList();
            return View(superheros);
        }

        //============================================================================================

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superheros superhero = new Superheros();
            return View(superhero);
           
        }

        //============================================================================================

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "SuperheroName,Alterego,PrimaryAbility,SecondaryAbility,Catchphrase")] Superheros superhero)
        {
            db.Superheros.Add(superhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //============================================================================================

        //GET: Superhero/Delete
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //===================================================================================================

        //POST: Superhero/Delete
        //[HttpPost]
        public ActionResult Delete(int id)
        {

            Superheros deleteSuperhero = db.Superheros.Where(s => s.ID == id).Single();
            db.Superheros.Remove(deleteSuperhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //===================================================================================================

        //GET: Superhero/Details
        public ActionResult Details(int id)
        {
            var superheroDetails = db.Superheros.Where(s => s.ID == id).First();
            return View(superheroDetails);
        }

        //===================================================================================================

        //POST: Superhero/Details
        [HttpPost]
        public ActionResult Details(Superheros superhero, int id)
        {
            Superheros superheroDetails = db.Superheros.Where(s => s.ID == superhero.ID).Single();
            return RedirectToAction("Index");
        }

        //===================================================================================================

        //GET: Superhero/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
           var editSuperhero = db.Superheros.Where(s => s.ID == id).Single();
            return View(editSuperhero);
        }

        //===================================================================================================

        [HttpPost]
        public ActionResult Edit([Bind(Include = "SuperheroName,Alterego,PrimaryAbility,SecondaryAbility,Catchphrase")] Superheros superhero, int id)
        {
            var editSuperhero = db.Superheros.Where(s => superhero.ID == superhero.ID).First();
            editSuperhero.SuperheroName = superhero.SuperheroName;
            editSuperhero.PrimaryAbility = superhero.PrimaryAbility;
            editSuperhero.SecondaryAbility = superhero.SecondaryAbility;
            editSuperhero.AlterEgo = superhero.AlterEgo;
            editSuperhero.Catchphrase = superhero.Catchphrase;
            //db.Superheros.Remove(editSuperhero);
            //db.Superheros.Add(editSuperhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}