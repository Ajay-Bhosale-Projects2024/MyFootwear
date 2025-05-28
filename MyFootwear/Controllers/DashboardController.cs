using Microsoft.Ajax.Utilities;
using MyFootwear.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Data.Entity;
using System.Security.Cryptography;

namespace MyFootwear.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        MyFootwearContext db = new MyFootwearContext();

        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["LoginCookie"];
            if (cookie["SellerId"].IsNullOrWhiteSpace())
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                db.Configuration.LazyLoadingEnabled = false;
                int SellerId = Convert.ToInt32(cookie["SellerId"]);
                List<Product> products = db.Products.Where(E => E.SellerId == SellerId).Include(E=>E.Brand).Include(T=>T.Type).ToList();
                return View(products);
            }
            
        }
        [Authorize]
        public ViewResult AddProduct()
        {
            ViewBag.BrandId=new SelectList(db.Brands.ToList(),"BrandID","BrandName","--select--");
            ViewBag.TypeId = new SelectList(db.Types.ToList(), "TypeID", "TypesName", "--select--");
            
            return View();
        }
        [Authorize]
        [HttpPost]        
        public RedirectToRouteResult AddProduct(Product product, int SellerId,HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                string physicalPath = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                selectedFile.SaveAs(physicalPath + selectedFile.FileName);
                product.Image = selectedFile.FileName;
            }
            product.SellerId = SellerId;            
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddBrand(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult AddType()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddType(MyFootwear.Models.Type type)
        {
            db.Types.Add(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}