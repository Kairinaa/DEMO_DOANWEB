using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVatTuPhanXuong.Models;
using PagedList;

namespace QuanLyVatTuPhanXuong.Controllers
{
    public class TNuocSXController : Controller
    {
        QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
        // GET: tNuocSX
/*        public ActionResult Index()
        {
            var ds = from water in db.tNuocSXes select water;
            return View(ds);
        }*/
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from water in db.tNuocSXes select water).OrderBy(x => x.MaNuoc);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber,pageSize));
        }
        /*        public ActionResult Delete(string id)
                {
                    tNuocSX nuocSX = db.tNuocSXes.Find(id);
                    db.tNuocSXes.Remove(nuocSX);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }*/
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tNuocSX nuocSX = db.tNuocSXes.Find(id);
            return View(nuocSX);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaNuoc");
            var dsnuoc = (from ds in db.tPhuKiens where ds.MaNuoc == id select ds).FirstOrDefault();
            if (dsnuoc==null)
            {
                tNuocSX nuocSX = db.tNuocSXes.Find(id);
                db.tNuocSXes.Remove(nuocSX);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tNuocSX nuocSX = db.tNuocSXes.Find(id);
            return View(nuocSX);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaNuoc");
            tNuocSX nuocSX = db.tNuocSXes.Find(ma);
            nuocSX.TenNuoc = f.Get("TenNuoc");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tNuocSX add)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            db.tNuocSXes.Add(add);
            db.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult Details(string id)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tNuocSX nuocSX = db.tNuocSXes.Find(id);
            return View(nuocSX);
        }
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaNuoc = f.Get("MaNuoc");
            var nuoc = db.tThoes.Find(MaNuoc);
            return RedirectToAction("details/" + MaNuoc);
        }
    }
}