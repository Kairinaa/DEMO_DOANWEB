using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyVatTuPhanXuong.Models;
using PagedList;

namespace QuanLyVatTuPhanXuong.Controllers
{
    public class tPhuKienController : Controller
    {
        QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
        // GET: tPhuKien
        /*        public ActionResult Index()
                {
                    var ds = from pk in db.tPhuKiens select pk;
                    return View(ds);
                }*/
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from pk in db.tPhuKiens select pk).OrderBy(x => x.MaPhuKien);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tPhuKien pk = db.tPhuKiens.Find(id);
            return View(pk);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string id = f.Get("MaPhuKien");
            var dspk = (from ds in db.tThanhPhans where ds.MaPhuKien == id select ds).FirstOrDefault();
            if (dspk == null)
            {
                tPhuKien pk = db.tPhuKiens.Find(id);
                db.tPhuKiens.Remove(pk);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tPhuKien pk = db.tPhuKiens.Find(id);

            return View(pk);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("MaPhuKien");
            tPhuKien pk = db.tPhuKiens.Find(ma);

            pk.TenPhuKien = f.Get("TenPhuKien");
            pk.GhiChu = f.Get("GhiChu");
            pk.SoLuongTonThucTe = Convert.ToInt32(f.Get("SoLuongTonThucTe"));
            pk.DonGia = Convert.ToInt32(f.Get("DonGia"));
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tPhuKien add)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            db.tPhuKiens.Add(add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            QuanLyVatTuPhanXuongXeEntities db = new QuanLyVatTuPhanXuongXeEntities();
            tPhuKien pk = db.tPhuKiens.Find(id);
            return View(pk);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string MaPhuKien = f.Get("MaPhuKien");
            string MaNuoc = f.Get("MaNuoc");
            var pk = db.tXes.Find(MaPhuKien);
            return RedirectToAction("details/" + MaPhuKien + MaNuoc);
        }
    }
}