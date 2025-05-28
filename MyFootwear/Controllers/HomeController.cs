using MyFootwear.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace MyFootwear.Controllers
{
    public class HomeController : Controller
    {
        MyFootwearContext db = new MyFootwearContext();
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            List<Product> products = db.Products.Include(E => E.Brand).Include(T => T.Type).ToList();

            return View(products);
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public JsonResult Card(int? ProudctId)
        //{
        //    Product item = db.Products.Find(ProudctId);
        //    Card C = new Card
        //    { 
        //    ProudctId = item.ProudctId,
        //    ProductName = item.ProuductName,
        //    Price = item.Price,
        //     Image = item.Image,
        //     Size=item.Size
        //    };

        //    db.Cards.Add(C);
        //    db.SaveChanges();

        //    return Json(C,JsonRequestBehavior.AllowGet);
        //}

        public ViewResult CustomerRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerRegister(RegCust customer)
        {
            customer.Status = true;
            if(ModelState.IsValid)
            {
                db.CustomerRegister.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CustomerLogin");
            }
            else
            {
                return View(customer);
            }

            
        }

        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Login login)
        {
            var isvalid = from i in db.CustomerRegister where i.Email == login.Email && i.Password == login.Password select i;
            RegCust customer = isvalid.SingleOrDefault();
            if(isvalid.Count()==1)
            {
                Session["CustomerName"] = customer.CName.ToString();
                Session["CustomerId"] = customer.CustomerId.ToString();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials.");
                return View(login);
            }
            
        }

        public RedirectToRouteResult CustLogout()
        {
            Session["CustomerName"] = null;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Cart1()
        {
            if (Session["CustomerName"]==null)
            {
                return RedirectToAction("CustomerLogin");
            }
            else
            {
                int CustomerId = Convert.ToInt32(Session["CustomerId"]);
                List<Cart> carts = db.Carts.Where(E => E.CustomerId == CustomerId && E.Status==true).ToList();
                return Json(carts, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult Cart3()
        {
            if(Session["CustomerName"] == null)
            {
                return RedirectToAction("CustomerLogin", "Home");
            }
            else
            {
                return View();
            }
            
        }
        
        [HttpPost]
        public ActionResult Cart(int ProudctId)
        {
            if (Session["CustomerName"]!=null)
            {

                var product = db.Products.Where(E => E.ProudctId == ProudctId).Single();
                Cart c1 = new Cart
                {
                    CustomerId = Convert.ToInt32(Session["CustomerId"]),
                    ProductId = product.ProudctId,
                    ProductName = product.ProuductName,
                    Image = product.Image,
                    Price = product.Price,
                    Status = true,
                    

                };
                decimal d = product.Price;
                ViewBag.Total = product.Price+d;
                db.Carts.Add(c1);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("CustomerLogin","Home");
            }
        }

        public JsonResult Delete(int? CartId)
        {
            if (CartId != null)
            {
                Cart c = (from i in db.Carts.Where(E => E.CartId == CartId) select i).SingleOrDefault();
                c.Status = false;
                Session["Total"] =- c.Price;
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Not Deleted", JsonRequestBehavior.AllowGet);
            }
            
        }
        
        public ViewResult Buy(int ProudctId)
        {
            int custid = Convert.ToInt32(Session["CustomerId"]);
            Product productDetails = db.Products.Include(E => E.Brand).Where(E => E.ProudctId == ProudctId).Single();
            var customer = db.CustomerRegister.Find(custid);
            ViewBag.cname=customer.CName;
            ViewBag.Address=customer.Shipping_Address;
            ViewBag.Mobile=customer.PrimaryMobile;
            
            return View(productDetails);
        }

        [HttpPost]
        public RedirectToRouteResult Order(int ProudctId)
        {
            //add data into order table
            return RedirectToAction("index");
        }

        public ViewResult Order2(params int[] paramse)
        {

            return View();
        }
    }
}