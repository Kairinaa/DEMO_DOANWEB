using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVatTuPhanXuong.Models;
using PagedList;

namespace QuanLyVatTuPhanXuong.Controllers
{
    public class tXeController : Controller
    {
        // GET: tXe
        QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
        /*        public ActionResult Index()
                {
                    var ds = from xe in db.tXes select xe;
                    return View(ds);
                }*/
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from xe in db.tXes select xe).OrderBy(x => x.MaXe);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tXe xe = db.tXes.Find(id);
            return View(xe);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaXe");
            var dsxe = (from ds in db.tThanhPhans where ds.MaXe == id select ds).FirstOrDefault();
            if (dsxe == null)
            {
                tXe xe = db.tXes.Find(id);
                db.tXes.Remove(xe);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tXe xe = db.tXes.Find(id);
            return View(xe);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaXe");
            tXe xe = db.tXes.Find(ma);
            xe.TenXe = f.Get("TenXe");
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tXe add)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            db.tXes.Add(add);
            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tXe xe = db.tXes.Find(id);
            return View(xe);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaXe = f.Get("MaXe");
            var xe = db.tXes.Find(MaXe);
            return RedirectToAction("details/" + MaXe);
        }
    }
}