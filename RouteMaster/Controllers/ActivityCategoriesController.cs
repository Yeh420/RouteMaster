﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RouteMaster.Models.EFModels;

namespace RouteMaster.Controllers
{
    public class ActivityCategoriesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ActivityCategories
        public ActionResult Index()
        {
            return View(db.ActivityCategories.ToList());
        }

        // GET: ActivityCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        // GET: ActivityCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityCategories/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ActivityCategory activityCategory)
        {
            if (ModelState.IsValid)
            {
                db.ActivityCategories.Add(activityCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityCategory);
        }

        // GET: ActivityCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        // POST: ActivityCategories/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ActivityCategory activityCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityCategory);
        }

        // GET: ActivityCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            if (activityCategory == null)
            {
                return HttpNotFound();
            }
            return View(activityCategory);
        }

        // POST: ActivityCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityCategory activityCategory = db.ActivityCategories.Find(id);
            db.ActivityCategories.Remove(activityCategory);
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
