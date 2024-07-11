using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjCustomer.Models;

namespace prjCustomer.Controllers
{
    public class HomeController : Controller
    {
        dbCustomerEntities db = new dbCustomerEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            var customers = db.tCustomer.OrderBy(m => m.CId).ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tCustomer vCustomer)
        {
            db.tCustomer.Add(vCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CId)
        {
            var customer = db.tCustomer.Where(m => m.CId == CId).FirstOrDefault();
            db.tCustomer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int CId)
        {
            var customer = db.tCustomer.Where(m => m.CId == CId).FirstOrDefault();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(tCustomer vCustomer)
        {
            int CId = vCustomer.CId;
            var customer = db.tCustomer.Where(m => m.CId == CId).FirstOrDefault();
            customer.CName = vCustomer.CName;
            customer.CCity = vCustomer.CCity;
            customer.CPhone = vCustomer.CPhone;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int CId)
        {
            var customer = db.tCustomer.Find(CId);
            return View(customer);
        }
    }
}