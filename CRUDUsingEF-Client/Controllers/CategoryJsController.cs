﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingEF_Client.Controllers
{
    public class CategoryJsController : Controller
    {
        // GET: CategoryJs
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryJs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryJs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryJs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryJs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryJs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryJs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryJs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
