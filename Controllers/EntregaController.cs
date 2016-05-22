using ServiExpress.Models;
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
    public class EntregaController : Controller
    {
        ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();
        ClienteServicio ClienteServicio = new ClienteServicio();
        RepartidorServicio RepartidorServicio = new RepartidorServicio();
        EntregaServicio EntregaServicio = new EntregaServicio();
        //
        // GET: /Entrega/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Entrega/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Entrega/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Entrega/Create

        [HttpPost]
        public ActionResult Create(tbEntregas collection)
        {
            collection.idCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).IdCliente;
            EntregaServicio.Crear(collection);
            return View("../Cliente/Index");
               
        }

        //
        // GET: /Entrega/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Entrega/Edit/5

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

        //
        // GET: /Entrega/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Entrega/Delete/5

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
