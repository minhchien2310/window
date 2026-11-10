using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLHH1.Models;

namespace QLHH1.Controllers
{
    public class PhieuthueController : Controller
    {
     
        private readonly QLHH1Context db;
        // 1. TRANG INDEX
        public PhieuthueController(QLHH1Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.ds = db.Phieuthues.Include(p => p.MaKhNavigation).ToList();
            return View();
        }

        // 2. TRANG THÊM
        [HttpGet]
        public ActionResult them()
        {
            // Nạp danh sách Khách hàng vào SelectList cho Dropdown view
            ViewBag.MaKh = new SelectList(db.Khachhangs.ToList(), "MaKh", "TenKh");
            return View();
        }

        // 2. TRANG THÊM (POST)
        [HttpPost]
        public ActionResult them(Phieuthue p)
        {
            // Bỏ qua kiểm tra validation của thuộc tính liên kết bảng
            ModelState.Remove("MaKhNavigation");

            if (ModelState.IsValid)
            {
                if (db.Phieuthues.Find(p.MaPt) != null)
                {
                    ModelState.AddModelError("", "Mã phiếu thuê bị trùng khóa chính!");
                    ViewBag.MaKh = new SelectList(db.Khachhangs.ToList(), "MaKh", "TenKh", p.MaKh);
                    return View(p);
                }

                db.Phieuthues.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, nạp lại SelectList để hiển thị lại View
            ViewBag.MaKh = new SelectList(db.Khachhangs.ToList(), "MaKh", "TenKh", p.MaKh);
            return View(p);
        }
        // 3. TRANG XÓA
        [HttpGet]
        public ActionResult xoa(string id)
        {
            Phieuthue p = db.Phieuthues.Include(x => x.MaKhNavigation).FirstOrDefault(x => x.MaPt == id);
            return View(p);
        }

        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            Phieuthue p = db.Phieuthues.Find(id);
            if (p != null)
            {
                db.Phieuthues.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}