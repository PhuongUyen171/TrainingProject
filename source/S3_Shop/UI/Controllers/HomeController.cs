﻿using API.Controllers;
using API.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private ServiceRepository serviceObj;
        private string url = "https://localhost:44379/";

        #region trang tĩnh
        public ActionResult Index()
        {
            int num = 8;
            var url = "https://localhost:44379/";
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse(url + "api/Product_API/GetNewProductsByCount?count="+num);
            response.EnsureSuccessStatusCode();
            List<Model.ProductModel> list = response.Content.ReadAsAsync<List<Model.ProductModel>>().Result;
            return View(list);
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

        public ActionResult TinTuc()
        {
            var url = "https://localhost:44379/";
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse(url + "api/News");
            response.EnsureSuccessStatusCode();
            List<Model.NewsModel> list = response.Content.ReadAsAsync<List<Model.NewsModel>>().Result;
            
            return View(list);
        }
        #endregion

        #region partial
        public ActionResult CategoryPartial()
        {            
            serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse(url + "api/Category_API/GetAllCategories");
            response.EnsureSuccessStatusCode();
            List<Model.CategoryModel> list = response.Content.ReadAsAsync<List<Model.CategoryModel>>().Result;

            return View(list);
        }
        public ActionResult SearchPartial()
        {
            return PartialView();
        }
        #endregion

        [HttpPost]
        public ActionResult SearchProducts(FormCollection c)
        {
            var url = "https://localhost:44379/";
            ServiceRepository serviceObj = new ServiceRepository();
            //List sản phẩm
            var tim = c["searchText"];
            HttpResponseMessage responseListProduct = serviceObj.GetResponse(url + "api/Product_API/GetProductsBySearch?tim=" + tim);
            responseListProduct.EnsureSuccessStatusCode();
            List<Model.ProductModel> list = responseListProduct.Content.ReadAsAsync<List<Model.ProductModel>>().Result;
            return View(list);
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