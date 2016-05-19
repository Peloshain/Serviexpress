﻿using ServiExpress.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiExpress.Servicios;

namespace ServiExpress.Controllers
{
    public class ClienteController : Controller
    {
        ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        ClienteServicio ClienteServicio = new ClienteServicio();
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            tbClientes cliente = new tbClientes();
            cliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name);
            return View(cliente);
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id)
        {

            
                return View();
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(tbClientes collection)
        {
            ClienteServicio.Crear(collection);
            return View("../Home/Index");
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id)
        {
            
            var tbClientes = ClienteServicio.ObtenerCliente(id);
            return View(tbClientes);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, tbClientes collection)
        {

            try
            {
                if (db != null)

                db.Dispose();
                db.tbClientes.Attach(collection);
                db.Entry(collection).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("../Cliente/Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cliente/Delete/5

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
