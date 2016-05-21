using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiExpress.Servicios;
using ServiExpress.Models;

namespace ServiExpress.Controllers
{
    public class PagoController : Controller
    {
        //
        ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();
        ContratoServicio ContratoServicio = new ContratoServicio();
        ClienteServicio ClienteServicio = new ClienteServicio();
        PagoServicio PagoServicio = new PagoServicio();
        // GET: /Pago/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Pago/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pago/Create

        public ActionResult Create()
        {
            tbContrato contrato = new tbContrato();
            contrato.idCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).IdCliente;
            contrato.IdContrato = ContratoServicio.ObtenerContrato(Convert.ToInt32(contrato.idCliente)).IdContrato;
            contrato.Monto = PagoServicio.MontoMensual(contrato.IdContrato).Monto;
            ViewBag.Contrato = contrato;
            return View();
        }

        //
        // POST: /Pago/Create

        [HttpPost]
        public ActionResult Create(tbPagos collection)
        {
            collection.idCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).IdCliente;
            collection.idcontrato = ContratoServicio.ObtenerContrato(Convert.ToInt32(collection.idCliente)).IdContrato;
            collection.Monto = PagoServicio.MontoMensual(collection.idcontrato).Monto;
            PagoServicio.Crear(collection);
            return View("../Cliente/Index");
        }

        //
        // GET: /Pago/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pago/Edit/5

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
        // GET: /Pago/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pago/Delete/5

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
