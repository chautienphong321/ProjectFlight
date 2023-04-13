using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_LMS.Models;

namespace Project_LMS.Controllers
{
    public class Danh_sách_giáo_viênController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: Danh_sách_giáo_viên
        public ActionResult Index(string SearchString = "", string Searchtobomon = "", string Searchloaihopdong = "", string Searchtrangthai = "")
        {
            //return View(db.Danh_sách_giáo_viên.ToList());
            var dsgiaovien = from x in db.Danh_sách_giáo_viên select x;
            if (SearchString != "")
            {
                dsgiaovien = dsgiaovien.Where(x => x.Hovaten.Contains(SearchString));
            }
            if (Searchtobomon != "")
            {
                dsgiaovien = dsgiaovien.Where(x => x.Tobomon.Contains(Searchtobomon));
            }
            if (Searchloaihopdong != "")
            {
                dsgiaovien = dsgiaovien.Where(x => x.Loaihopdong.Contains(Searchloaihopdong));
            }
            if (Searchtrangthai != "")
            {
                dsgiaovien = dsgiaovien.Where(x => x.Trangthai.Contains(Searchtrangthai));
            }
            return View(dsgiaovien.ToList());
        }

        // GET: Danh_sách_giáo_viên/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_giáo_viên danh_sách_giáo_viên = db.Danh_sách_giáo_viên.Find(id);
            if (danh_sách_giáo_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_giáo_viên);
        }

        // GET: Danh_sách_giáo_viên/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Danh_sách_giáo_viên/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magiangvien,Hovaten,Mangach,Chucvu,Tobomon,Loaihopdong,Ngayvaotruong,Nghiphep,Trangthai,Gioitinh,Ngaysinh,SoCMND,Ngaycap,Noicap,Diachi,SoBHXH,Trinhdodaotao,Ngayapdungchucvu,Ngaybatdaulamviec,Ngach_hang,Bacluong,Hesoluong,Ngayapdungngachbac,Phucap,Luongcoban")] Danh_sách_giáo_viên danh_sách_giáo_viên)
        {
            if (ModelState.IsValid)
            {
                db.Danh_sách_giáo_viên.Add(danh_sách_giáo_viên);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danh_sách_giáo_viên);
        }

        // GET: Danh_sách_giáo_viên/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_giáo_viên danh_sách_giáo_viên = db.Danh_sách_giáo_viên.Find(id);
            if (danh_sách_giáo_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_giáo_viên);
        }

        // POST: Danh_sách_giáo_viên/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magiangvien,Hovaten,Mangach,Chucvu,Tobomon,Loaihopdong,Ngayvaotruong,Nghiphep,Trangthai,Gioitinh,Ngaysinh,SoCMND,Ngaycap,Noicap,Diachi,SoBHXH,Trinhdodaotao,Ngayapdungchucvu,Ngaybatdaulamviec,Ngach_hang,Bacluong,Hesoluong,Ngayapdungngachbac,Phucap,Luongcoban")] Danh_sách_giáo_viên danh_sách_giáo_viên)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_sách_giáo_viên).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_sách_giáo_viên);
        }

        // GET: Danh_sách_giáo_viên/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_giáo_viên danh_sách_giáo_viên = db.Danh_sách_giáo_viên.Find(id);
            if (danh_sách_giáo_viên == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_giáo_viên);
        }

        // POST: Danh_sách_giáo_viên/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Danh_sách_giáo_viên danh_sách_giáo_viên = db.Danh_sách_giáo_viên.Find(id);
            db.Danh_sách_giáo_viên.Remove(danh_sách_giáo_viên);
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
