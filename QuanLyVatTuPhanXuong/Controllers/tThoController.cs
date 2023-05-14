using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVatTuPhanXuong.Models;
using PagedList;

namespace QuanLyVatTuPhanXuong.Controllers
{
    public class tThoController : Controller
    {
        QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
        // GET: tTho
        /*        public ActionResult Index()
                {
                    var ds = from tho in db.tThoes select tho;
                    return View(ds);
                }*/
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from tho in db.tThoes select tho).OrderBy(x => x.MaTho);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tTho tho = db.tThoes.Find(id);
            return View(tho);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaTho");
            var dstho = (from ds in db.tThanhPhans where ds.MaXe == id select ds).FirstOrDefault();
            if (dstho == null)
            {
                tTho tho = db.tThoes.Find(id);
                db.tThoes.Remove(tho);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tTho tho = db.tThoes.Find(id);
            return View(tho);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaTho");
            tTho tho = db.tThoes.Find(ma);
            tho.TenTho = f.Get("TenTho");
            tho.BacTho = f.Get("BacTho");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tTho add)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            db.tThoes.Add(add);
            db.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult Details(string id)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tTho tho = db.tThoes.Find(id);
            return View(tho);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaTho = f.Get("MaTho");
            var lk = db.tThoes.Find(MaTho);
            return RedirectToAction("details/" + MaTho);
        }
    }
}