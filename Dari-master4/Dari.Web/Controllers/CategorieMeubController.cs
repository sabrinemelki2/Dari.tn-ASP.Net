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
    public class CategorieMeubController : Controller
    {
        IDataBaseFactory dbf;
        IUnitOfWork uow;
        IService<Annonce> ServiceAnnonce;
        IService<Rate> ServiceRate;
        IService<Client> ServiceClient;
        IService<CategorieMeub> CategorieService;
        public CategorieMeubController()
        {
            dbf = new DataBaseFactory();
            uow = new UnitOfWork(dbf);
            ServiceAnnonce = new Service<Annonce>(uow);
            ServiceClient = new Service<Client>(uow);
            ServiceRate = new Service<Rate>(uow);
            CategorieService = new Service<CategorieMeub>(uow);
        }
        // GET: CategorieMeub
        public ActionResult Index()
        {
            return View(CategorieService.GetAll());
        }

        // GET: CategorieMeub/Details/5
        public ActionResult Details(int id)
        {
            return View(CategorieService.GetById(id));
        }

        // GET: CategorieMeub/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategorieMeub/Create
        [HttpPost]
        public ActionResult Create(CategorieMeub cat)
        {

            // TODO: Add insert logic here

            CategorieService.Add(cat);
            CategorieService.Commit();

                return RedirectToAction("Index");
            
           
        }

        // GET: CategorieMeub/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategorieService.GetById(id));
        }

        // POST: CategorieMeub/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategorieMeub cat)

        {
            try
            {
                // TODO: Add update logic here
                CategorieService.Update(cat);
                CategorieService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieMeub/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CategorieService.GetById(id));
        }

        // POST: CategorieMeub/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                // TODO: Add delete logic here
                CategorieService.Delete(CategorieService.GetById(id));
                CategorieService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
