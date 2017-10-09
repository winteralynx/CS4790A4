using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS4790A4.Models;
using CS4790A4.Extensions; 

namespace CS4790A4.Controllers
{
    public class ProposalsController : Controller
    {
        private ARCCDbContext db = new ARCCDbContext();

        // GET: Proposals
        public ActionResult Index()
        {

            return View(db.Proposals.ToList());
        }

        // GET: Proposals/searchEmail/test@gmail.com   Proposals By email
        public ActionResult searchEmail(string email)
        {

            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            email = email.FromBase64();
            //Proposal proposal = db.Proposals.Find(email);
            //Proposal proposal = db.Proposals.Where(i => i.Email == email); 
            List<Proposal> proposal = db.Proposals.Where(i => i.Email == email).ToList();
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
            
        }

        // GET: Proposals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // GET: Proposals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProposalName,EdExpRating,InnovationRating,DissemRating,EvalRating,SupportRating,Email")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                db.Proposals.Add(proposal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proposal);
        }

        // GET: Proposals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProposalName,EdExpRating,InnovationRating,DissemRating,EvalRating,SupportRating")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proposal);
        }

        // GET: Proposals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposal proposal = db.Proposals.Find(id);
            if (proposal == null)
            {
                return HttpNotFound();
            }
            return View(proposal);
        }

        // POST: Proposals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposal proposal = db.Proposals.Find(id);
            db.Proposals.Remove(proposal);
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
