using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3_Shop.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChinhSachBanHang()
        {
            return View();
        }

        public ActionResult HuongDanMuaHang()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult TuyenDung()
        {
            return View();
        }
       
        public ActionResult HeThong()
        {
            return View();
        }

        public ActionResult VanHoa()
        {
            return View();
        }

        public ActionResult GetCategory()
        {
            return PartialView();
        }

        
        //public ActionResult ChiNhanhHaNoi()
        //{
        //    var hn = data.CUAHANGs.Where(m => m.Vung == "HN");
        //    return View(hn);
        //}
        //public ActionResult ChiNhanhHCM()
        //{
        //    var hcm = data.CUAHANGs.Where(m => m.Vung == "HCM");
        //    return View(hcm);
        //}
        //public ActionResult TinTuc()
        //{
        //    var tintuc = from tt in data.TINTUCs select tt;
        //    return View(tintuc);
        //}
        //public ActionResult ChiTietTinTuc(string id)
        //{
        //    var chitiet = data.TINTUCs.First(m => m.MaTin == id);
        //    return View(chitiet);
        //}
    }
}