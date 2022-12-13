using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using Dari.service;
using Dari.Service;
using DariTn.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dari.Web.Controllers
{
    public class MeubleController : Controller
    {

        IDataBaseFactory dbf;
        IUnitOfWork uow;
        IService<Annonce> ServiceAnnonce;
        IService<Rate> ServiceRate;
        IService<Client> ServiceClient;
        IService<CategorieMeub> CategorieService;
        IService<Meuble> MeubleService;
        public MeubleController()
        {
            dbf = new DataBaseFactory();
            uow = new UnitOfWork(dbf);
            ServiceAnnonce = new Service<Annonce>(uow);
            ServiceClient = new Service<Client>(uow);
            ServiceRate = new Service<Rate>(uow);
            CategorieService = new Service<CategorieMeub>(uow);
            MeubleService = new Service<Meuble>(uow);
        }
        // GET: Meuble
        public ActionResult Index()
        {
            return View(MeubleService.GetAll());
        }

        // GET: Meuble/Details/5
        public ActionResult Details(int id)
        {
            return View(MeubleService.GetById(id));
        }

        // GET: Meuble/Create
        public ActionResult Create()
        {
            ViewBag.CategoryMeubId = new SelectList(MeubleService.GetAll(), "CategoryMeubId", "Name");
            return View();

        }

        // POST: Meuble/Create
        [HttpPost]
        public ActionResult Create(Meuble MVM, HttpPostedFileBase file)
        {
            try
            {

                MVM.Image = file.FileName;
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                    file.SaveAs(path);
                }
                MeubleService.Add(MVM);
                MeubleService.Commit();

                return RedirectToAction("Index");


            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        // GET: Meuble/Edit/5
        public ActionResult Edit(int id)
        {



            return View(MeubleService.GetById(id));
        }

        // POST: Meuble/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Meuble MVM) // FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                MeubleService.Update(MVM);
                MeubleService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Meuble/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MeubleService.GetById(id));
        }

        // POST: Meuble/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MeubleService.Delete(MeubleService.GetById(id));
                MeubleService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult statistique()
        {




            int A = 0;
            int B = 0;
            int C = 0;

            var MyCategory = CategorieService.GetAll();
            List<CategorieMeub> cc = new List<CategorieMeub>();
            foreach (var item in MyCategory)
            {
                cc.Add(item);
            }
            List<Meuble> p1 = new List<Meuble>();
            List<Meuble> p2 = new List<Meuble>();
            List<Meuble> p3 = new List<Meuble>();
            List<Meuble> p4 = new List<Meuble>();
            foreach (var itemm in MeubleService.GetAll().Where(e => e.CategoryMeubId == cc[0].CategoryMeubId))
            {
                p1.Add(itemm);
            }
            foreach (var itemm in MeubleService.GetAll().Where(e => e.CategoryMeubId == cc[1].CategoryMeubId))
            {
                p2.Add(itemm);
            }
            foreach (var itemm in MeubleService.GetAll().Where(e => e.CategoryMeubId == cc[2].CategoryMeubId))
            {
                p3.Add(itemm);
            }
            foreach (var itemm in MeubleService.GetAll().Where(e => e.CategoryMeubId == cc[3].CategoryMeubId))
            {
                p4.Add(itemm);
            }



            ViewData["countA"] = p1.Count;
            ViewData["countB"] = p2.Count;
            ViewData["countC"] = p3.Count;
            ViewData["countD"] = p4.Count;





            return View();
        }


        [HttpPost]
        public ActionResult Index(string rech)
        {

            var list = MeubleService.GetAll();

            if (!String.IsNullOrEmpty(rech))
            {
                list = list.Where(m => m.Titre.Contains(rech)).ToList();

            }

            return View(list);

        }
    }


}

