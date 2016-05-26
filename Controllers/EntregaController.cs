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
        public ActionResult ObtenerEntrega(string term)
        {
            var model = EntregaServicio.ObtenerPorOrden(Convert.ToInt32(term));
            
            var objentrega = new tbEntregas();
            objentrega.NombreConsumidor = model.NombreConsumidor;
            objentrega.Descripcion = model.Descripcion;
            objentrega.TelefonoConsumidor = model.TelefonoConsumidor;
            objentrega.Estado = model.Estado;
         
            return Json(objentrega, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Entrega/Details/5

        public ActionResult Monitoreo(int id)
        {
            ViewBag.Orden = new SelectList(EntregaServicio.ObtenerLista(), "IdOrden", "IdOrden", "");
            tbEntregas entregas= new tbEntregas();
            entregas = EntregaServicio.ObtenerOrdenPorIdCliente(id);

            return View(entregas);
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
