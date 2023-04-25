using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Site.Models;

namespace MVC_Site.Controllers
{
    public class MVCregUsersEmpController : Controller
    {
        private SampleDBEntities db = new SampleDBEntities();

        // GET: MVCregUsersEmp
        public ActionResult Index()
        {
            return View(db.MVCregUsers.ToList());
        }

        // GET: MVCregUsersEmp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCregUser mVCregUser = db.MVCregUsers.Find(id);
            if (mVCregUser == null)
            {
                return HttpNotFound();
            }
            return View(mVCregUser);
        }

        // GET: MVCregUsersEmp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCregUsersEmp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Uname,Uemail,Upwd,Gender,Uimg")] MVCregUser mVCregUser)
        {
            if (ModelState.IsValid)
            {
                db.MVCregUsers.Add(mVCregUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVCregUser);
        }

        // GET: MVCregUsersEmp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCregUser mVCregUser = db.MVCregUsers.Find(id);
            if (mVCregUser == null)
            {
                return HttpNotFound();
            }
            return View(mVCregUser);
        }

        // POST: MVCregUsersEmp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Uname,Uemail,Upwd,Gender,Uimg")] MVCregUser mVCregUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVCregUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVCregUser);
        }

        // GET: MVCregUsersEmp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCregUser mVCregUser = db.MVCregUsers.Find(id);
            if (mVCregUser == null)
            {
                return HttpNotFound();
            }
            return View(mVCregUser);
        }

        // POST: MVCregUsersEmp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVCregUser mVCregUser = db.MVCregUsers.Find(id);
            db.MVCregUsers.Remove(mVCregUser);
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
