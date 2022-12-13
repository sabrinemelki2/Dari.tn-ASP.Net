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
    public class AnnoceController : Controller
    {
        IDataBaseFactory dbf;
        IUnitOfWork uow;
        IService<Annonce> ServiceAnnonce;
        IService<Rate> ServiceRate;
        IService<Client> ServiceClient;
        public AnnoceController()
        {
            dbf = new DataBaseFactory();
            uow = new UnitOfWork(dbf);
            ServiceAnnonce = new Service<Annonce>(uow);
            ServiceClient = new Service<Client>(uow);
            ServiceRate = new Service<Rate>(uow);
        }
        // GET: Annoce
        public ActionResult Index(string filtre , string min , string max , string type)
        {
            var list = ServiceAnnonce.GetAll();
            var YourRadioButt = Request.Form["type"];
            string aa = YourRadioButt;
            if(aa=="A")
                {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre)&& m.price >= con&& m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Vente" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Vente"&& m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m =>  m.price >= con && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m =>  m.TypeAn.ToString() == "Vente" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    
                    list = list.Where(m => m.TypeAn.ToString() == "Vente" ).ToList();
                }
            }
            if (aa == "B")
            {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre) && m.price >= con && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Location" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Location" && m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.price >= con && m.TypeAn.ToString() == "Location").ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.TypeAn.ToString() == "Location" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {

                    list = list.Where(m => m.TypeAn.ToString() == "Location").ToList();
                }
            }
            if (aa == "C")
            {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre) ).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre) && m.price >= con ).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre)  && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 ).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2  && m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.price >= con ).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m =>  m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {

                    
                }
            }



            return View(list);



        }


        // GET: Annoce/Details/5
        public ActionResult Details(int id)
        {
            return View(ServiceAnnonce.GetById(id));
        }
        public ActionResult Indexx()
        {
            return View(ServiceAnnonce.GetAll());
        }
        public double moyenne(int AnnonceID)
        {
           
            var eq = ServiceRate.GetAll().Where(x => x.AnnonceID == AnnonceID).Select(x => x.Rating).Average();
                return eq;
            
        
            
          

        }
        public ActionResult Edit(int id)
        {
            return View(ServiceAnnonce.GetById(id));
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Annonce p)
        {
            try
            {
               



                ServiceAnnonce.Update(p);
                ServiceAnnonce.Commit();
                return RedirectToAction("Indexx");
            }
            catch
            {
                return View();
            }
        }

        // GET: Annoce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Annoce/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Annonce p , HttpPostedFileBase file)
        {

            p.images = file.FileName;
            ServiceAnnonce.Add(p);
            ServiceAnnonce.Commit();
            Rate Rate = new Rate();
            Rate.Rating = 0;
            Rate.AnnonceID = p.AnnonceId;
            ServiceRate.Add(Rate);
            ServiceRate.Commit();
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/upload/"), file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Create");


        }

       
       

        
      

        // GET: Annoce/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ServiceAnnonce.GetById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Annonce p)
        {
            try
            {
                // TODO: Add delete logic here
                p = ServiceAnnonce.GetById(id);
                ServiceAnnonce.Delete(p);
                ServiceAnnonce.Commit();
                return RedirectToAction("Indexx");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Index_WS(string filtre, string min, string max, string type)
        {
            var list = ServiceAnnonce.GetAll();
            var YourRadioButt = Request.Form["type"];
            string aa = YourRadioButt;
            if (aa == "A")
            {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre) && m.price >= con && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Vente" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Vente" && m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.price >= con && m.TypeAn.ToString() == "Vente").ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.TypeAn.ToString() == "Vente" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {

                    list = list.Where(m => m.TypeAn.ToString() == "Vente").ToList();
                }
            }
            if (aa == "B")
            {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre) && m.price >= con && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre) && m.TypeAn.ToString() == "Location" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Location").ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.TypeAn.ToString() == "Location" && m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.price >= con && m.TypeAn.ToString() == "Location").ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.TypeAn.ToString() == "Location" && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {

                    list = list.Where(m => m.TypeAn.ToString() == "Location").ToList();
                }
            }
            if (aa == "C")
            {
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    list = list.Where(m => m.address.Contains(filtre)).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.address.Contains(filtre) && m.price >= con).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.address.Contains(filtre) && m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2).ToList();
                }
                if (!String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min); var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price >= con && m.price <= con2 && m.address.Contains(filtre)).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && !String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {
                    var con = Convert.ToInt32(min);
                    list = list.Where(m => m.price >= con).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && !String.IsNullOrEmpty(max))
                {
                    var con2 = Convert.ToInt32(max);
                    list = list.Where(m => m.price <= con2).ToList();
                }
                if (String.IsNullOrEmpty(filtre) && String.IsNullOrEmpty(min) && String.IsNullOrEmpty(max))
                {


                }
            }


            var json = list.ToList(); return Json(json.ToArray(), JsonRequestBehavior.AllowGet);
       



        }
        public ActionResult Create_WS(int TypeAn , string Description, string address , float surface, float price, int chambres)
        {

            Annonce p = new Annonce();
            p.TypeAn = (Dari.Domain.Entities.TypeAn)TypeAn;
            p.Description = Description;
            p.address = address;
            p.surface = surface;
            p.price = price;
            p.chambres = chambres;
            ServiceAnnonce.Add(p);
            ServiceAnnonce.Commit();

            return Json("create success", JsonRequestBehavior.AllowGet);


        }
        public ActionResult Indexx_WS()
        {
            
            var jsonn = ServiceAnnonce.GetAll().ToList();
            return Json(jsonn.ToArray(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit_WS(int id, int TypeAn, string Description, string address, float surface, float price, int chambres)
        {
            Annonce p = ServiceAnnonce.GetById(id);

            p.TypeAn = (Dari.Domain.Entities.TypeAn)TypeAn;
            p.Description = Description;
            p.address = address;
            p.surface = surface;
            p.price = price;
            p.chambres = chambres;

            ServiceAnnonce.Update(p);
            ServiceAnnonce.Commit();
            return Json("edit success", JsonRequestBehavior.AllowGet);


        }
        public ActionResult Delete_WS(int id)
        {
           Annonce r = ServiceAnnonce.GetById(id);
            ServiceAnnonce.Delete(r);
            ServiceAnnonce.Commit();
            return Json("delete success", JsonRequestBehavior.AllowGet);
        }

    }
}
