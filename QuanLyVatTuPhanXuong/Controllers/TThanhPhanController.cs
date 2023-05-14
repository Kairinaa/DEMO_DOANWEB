using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVatTuPhanXuong.Models;
using PagedList;

namespace QuanLyVatTuPhanXuong.Controllers
{
    public class TThanhPhanController : Controller
    {
        readonly QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
        // GET: tThanhPhan
        /*        public ActionResult Index()
                {
                    var ds = from tp in db.tThanhPhans select tp;
                    return View(ds);
                }*/
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from tp in db.tThanhPhans select tp).OrderBy(x => x.MaPhuKien);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id, string id2)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tThanhPhan thanhPhan = db.tThanhPhans.Find(id, id2);

            return View(thanhPhan);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tThanhPhan thanhPhan = db.tThanhPhans.Find(id, id2);
            db.tThanhPhans.Remove(thanhPhan);
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
    public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tThanhPhan add)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            db.tThanhPhans.Add(add);
            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Edit(string id, string id2)
        {
            tThanhPhan thanhPhan = db.tThanhPhans.Find(id, id2);
            return View(thanhPhan);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaXe");
            string ma2 = f.Get("MaPhuKien");
            tThanhPhan thanhPhan = db.tThanhPhans.Find(ma, ma2);
            thanhPhan.DVT = f.Get("DVT");
            thanhPhan.SoLuong = Convert.ToInt32(f.Get("SoLuong"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id, string id1)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tThanhPhan thanhPhan = db.tThanhPhans.Find(id, id1);
            return View(thanhPhan);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string maxe = f.Get("MaXe");
            string maphukien = f.Get("MaPhuKien");
           //var nt = db.tThanhPhans.Find(maxe, maphukien);
            // cai nao truoc
            return RedirectToAction("Details/" + maxe + "/" + maphukien);

        }
    }
}