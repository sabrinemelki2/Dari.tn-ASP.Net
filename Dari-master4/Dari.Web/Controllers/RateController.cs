using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using Dari.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dari.Web.Controllers
{
    public class RateController : Controller
    {
        IDataBaseFactory dbf;
        IUnitOfWork uow;
        IService<Rate> ServiceRate;
        IService<Client> ServiceClient;
        public RateController()
        {
            dbf = new DataBaseFactory();
            uow = new UnitOfWork(dbf);
            ServiceRate = new Service<Rate>(uow);
            ServiceClient = new Service<Client>(uow);
        }
        // GET: Rate
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rate/Create
        public ActionResult Create(int AnnonceId, int rate)
        {
            Rate Rate = new Rate();
            Rate.Rating = rate;
            Rate.AnnonceID = AnnonceId;
            ServiceRate.Add(Rate);
            ServiceRate.Commit();
            return RedirectToAction("Details", "Annoce", new { id = AnnonceId });
        }

        public double moyenne(int AnnonceID)
        {
            var eq = (from e in ServiceRate.GetAll() where e.AnnonceID == AnnonceID select e.Rating).Average()  ;
            return eq;

        }
        // POST: Rate/Create

        // GET: Rate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rate/Edit/5
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

        // GET: Rate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rate/Delete/5
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
