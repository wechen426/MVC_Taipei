﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class FormController : BaseController
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = db.Product.Find(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var product = db.Product.Find(id);

            if (TryUpdateModel(product, 
                includeProperties: new string[] { "ProductName" }))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            product = db.Product.Find(id);
            return View(product);
        }

    }
}