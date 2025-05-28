using MyFootwear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MyFootwear.Controllers
{
    public class AccountController : Controller
    {
        MyFootwearContext db = new MyFootwearContext();

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Seller seller)
        {
            if(ModelState.IsValid)
            {
                db.Sellers.Add(seller);
                db.SaveChanges();
                return RedirectToAction("Login","Account");
            }
            else
            {
                return View(seller);
            }           
            
        }

        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login,string ReturnUrl)        
        {
            if(ModelState.IsValid)
            {
                var record = from i in db.Sellers where (i.Email == login.Email && i.Password == login.Password) select i;
                
                if(record.Count()==1)
                {
                    Seller seller = record.SingleOrDefault();
                    FormsAuthentication.SetAuthCookie(seller.SellerName, false);                    
                    Session["UserName"]= seller.SellerName.ToString();
                    Session["SellerId"] = seller.SellerId;

                    HttpCookie cookie = new HttpCookie("LoginCookie");
                    cookie["SellerId"] = seller.SellerId.ToString();                     
                    Response.Cookies.Add(cookie);



                    if (ReturnUrl!=null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid-Credential...");
                    return View(login);
                }
                
                
            }
            else
            {
                return View(login);
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }


    }
}