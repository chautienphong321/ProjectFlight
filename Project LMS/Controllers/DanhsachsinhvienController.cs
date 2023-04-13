using Project_LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace WebApplication5.Controllers
{
    public class DanhsachsinhvienController : Controller
    {
        private LMSEntities db = new LMSEntities();
        // GET: Danhsachsinhvien
        public ActionResult Index(string SearchString = "", string searchGrade = "",
            string searchClass = "", string searchObject = "", string searchStatus = "")
        {
            var dssinhvien = from x in db.Danh_sách_sinh_viên select x;
            if (SearchString != "")
            {
                dssinhvien = dssinhvien.Where(x => x.tenhocvien.Contains(SearchString));
            }
            if (searchClass != "")
            {
                dssinhvien = dssinhvien.Where(x => x.lop.Contains(searchClass));
            }
            if (searchStatus != "")
            {
                dssinhvien = dssinhvien.Where(x => x.trangthai.Contains(searchStatus));
            }
            if (searchGrade != "")
            {
                dssinhvien = dssinhvien.Where(x => x.khoa_khoi.Contains(searchGrade));
            }
            if (searchObject != "")
            {
                dssinhvien = dssinhvien.Where(x => x.doituong.Contains(searchObject));
            }
            return View(dssinhvien.ToList());
        }
        // GET: Danhsachsinhvien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_sinh_viên danh_sách_sinh_viên = db.Danh_sách_sinh_viên.Find(id);
            if (danh_sách_sinh_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_sinh_viên);
        }

        // GET: Danhsachsinhvien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Danhsachsinhvien/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahocvien,tenhocvien,lop,khoa_khoi,doituong,sdt,ngaynhaphoc,hocphi,trangthai,thucthu,ngaythu")] Danh_sách_sinh_viên danh_sách_sinh_viên)
        {
            if (ModelState.IsValid)
            {
                db.Danh_sách_sinh_viên.Add(danh_sách_sinh_viên);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danh_sách_sinh_viên);
        }

        // GET: Danhsachsinhvien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_sinh_viên danh_sách_sinh_viên = db.Danh_sách_sinh_viên.Find(id);
            if (danh_sách_sinh_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_sinh_viên);
        }

        // POST: Danhsachsinhvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahocvien,tenhocvien,lop,khoa_khoi,doituong,sdt,ngaynhaphoc,hocphi,trangthai,thucthu,ngaythu")] Danh_sách_sinh_viên danh_sách_sinh_viên)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_sách_sinh_viên).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_sách_sinh_viên);
        }

        // GET: Danhsachsinhvien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_sinh_viên danh_sách_sinh_viên = db.Danh_sách_sinh_viên.Find(id);
            if (danh_sách_sinh_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_sinh_viên);
        }

        // POST: Danhsachsinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Danh_sách_sinh_viên danh_sách_sinh_viên = db.Danh_sách_sinh_viên.Find(id);
            db.Danh_sách_sinh_viên.Remove(danh_sách_sinh_viên);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Status(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_sinh_viên danh_sách_sinh_viên = db.Danh_sách_sinh_viên.Find(id);
            if (danh_sách_sinh_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_sinh_viên);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status([Bind(Include = "mahocvien,tenhocvien,lop,khoa_khoi,doituong,sdt,ngaynhaphoc,hocphi,trangthai,thucthu,ngaythu")] Danh_sách_sinh_viên danh_sách_sinh_viên)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_sách_sinh_viên).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_sách_sinh_viên);
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
