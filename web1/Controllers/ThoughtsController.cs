using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web1.Models;
using Microsoft.AspNet.Identity;
namespace web1.Controllers
{
    public class ThoughtsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Thoughts
       
        public ActionResult Index()
        {
            
                var userId = User.Identity.GetUserId();
                var thoughts = db.Thoughts.ToList();

                return View(thoughts);
            
            
        }

         
        // GET: Thoughts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thought thought = db.Thoughts.Find(id);
            if (thought == null)
            {
                return HttpNotFound();
            }
            return View(thought);
        }

        // GET: Thoughts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thoughts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Thoughts,Time")] Thought thought)
        {
            thought.UserId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(thought);


            if (ModelState.IsValid)
            {
                db.Thoughts.Add(thought);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thought);
        }

        // GET: Thoughts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thought thought = db.Thoughts.Find(id);
            if (thought == null)
            {
                return HttpNotFound();
            }
            return View(thought);
        }

        // POST: Thoughts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Thoughts,Time,UserId")] Thought thought)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thought).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thought);
        }

        // GET: Thoughts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thought thought = db.Thoughts.Find(id);
            if (thought == null)
            {
                return HttpNotFound();
            }
            return View(thought);
        }

        // POST: Thoughts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thought thought = db.Thoughts.Find(id);
            db.Thoughts.Remove(thought);
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
