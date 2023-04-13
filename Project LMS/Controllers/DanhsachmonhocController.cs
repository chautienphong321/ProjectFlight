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
    public class DanhsachmonhocController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: Danhsachmonhoc
       
        public ActionResult Index(string SearchString = "", string searchGrade = "",
            string SearchSubject = "", string searchStatus = "", string searchYear = "")
        {
            var dsmonhoc = from x in db.Danh_sách_môn_học select x;
            if (SearchString != "")
            {
                dsmonhoc = dsmonhoc.Where(x => x.Monhoc.Contains(SearchString));
            }
            if (SearchSubject != "")
            {
                dsmonhoc = dsmonhoc.Where(x => x.Monhoc.Contains(SearchSubject));
            }
            if (searchStatus != "")
            {
                dsmonhoc = dsmonhoc.Where(x => x.Trangthai.Contains(searchStatus));
            }
            if (searchGrade != "")
            {
                dsmonhoc = dsmonhoc.Where(x => x.Khoa_khoi.Contains(searchGrade));
            }
            if (searchYear != "")
            {
                dsmonhoc = dsmonhoc.Where(x => x.Nienkhoa1.Contains(searchYear));
            }
            return View(dsmonhoc.ToList());
        }

        // GET: Danhsachmonhoc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_môn_học danh_sách_môn_học = db.Danh_sách_môn_học.Find(id);
            if (danh_sách_môn_học == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_môn_học);
        }

        // GET: Danhsachmonhoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Danhsachmonhoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mamonhoc,Monhoc,Khoa_khoi,Donvitinh,Trangthai,Tonghocphi,Mucthumoidonvi,Nienkhoa,Thoiluong,Thoiluongmonhoc,Tonghocphiphaithu,Nienkhoa1")] Danh_sách_môn_học danh_sách_môn_học)
        {
            if (ModelState.IsValid)
            {
                danh_sách_môn_học.Tonghocphiphaithu = danh_sách_môn_học.Thoiluongmonhoc * danh_sách_môn_học.Mucthumoidonvi;
                db.Danh_sách_môn_học.Add(danh_sách_môn_học);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danh_sách_môn_học);
        }

        // GET: Danhsachmonhoc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_môn_học danh_sách_môn_học = db.Danh_sách_môn_học.Find(id);
            if (danh_sách_môn_học == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_môn_học);
        }

        // POST: Danhsachmonhoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mamonhoc,Monhoc,Khoa_khoi,Donvitinh,Trangthai,Tonghocphi,Mucthumoidonvi,Nienkhoa,Thoiluong,Thoiluongmonhoc,Tonghocphiphaithu,Nienkhoa1")] Danh_sách_môn_học danh_sách_môn_học)
        {
            if (ModelState.IsValid)
            {
                danh_sách_môn_học.Tonghocphiphaithu = danh_sách_môn_học.Thoiluongmonhoc * danh_sách_môn_học.Mucthumoidonvi;
                db.Entry(danh_sách_môn_học).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_sách_môn_học);
        }

        // GET: Danhsachmonhoc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danh_sách_môn_học danh_sách_môn_học = db.Danh_sách_môn_học.Find(id);
            if (danh_sách_môn_học == null)
            {
                return HttpNotFound();
            }
            return View(danh_sách_môn_học);
        }

        // POST: Danhsachmonhoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Danh_sách_môn_học danh_sách_môn_học = db.Danh_sách_môn_học.Find(id);
            db.Danh_sách_môn_học.Remove(danh_sách_môn_học);
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
