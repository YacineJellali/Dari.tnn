using Dari.Domain.Entities;
using Dari.service;
using Dari.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Dari.web.Controllers
{
    public class AdminController : Controller
    {
        IClientService service;


        public AdminController()
        {
            service = new ClientService();

        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(service.GetMany());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetById(id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Client cli)
        {
            try
            {


                service.Add(cli);
                service.Commit();

                return RedirectToAction("Index");


            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetById(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(service.GetById(id));
                service.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        public ActionResult Index(string rech)
        {

            var list = service.GetAll();

            if (!String.IsNullOrEmpty(rech))
            {
                list = list.Where(m =>  m.Prenom.Contains(rech) | m.Nom.Contains(rech) | m.Telephone.Contains(rech)).ToList();

            }

            return View(list);

        }
    }
}
