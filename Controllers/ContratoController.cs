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
    public class ContratoController : Controller
    {
        ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();
        ContratoServicio ContratoServicio = new ContratoServicio();
        ClienteServicio ClienteServicio = new ClienteServicio();
        TipoContratoServicio TipoContratoServicio = new TipoContratoServicio();
        //
        // GET: /Contrato/
        public ActionResult ObtenerContrato(string term){
            var model = TipoContratoServicio.ObtenerPorID(Convert.ToInt32(term));
            model.tbContrato = null;
            var tipoContrato = new tbTipoContrato();
            tipoContrato.Descripcion = model.Descripcion;
            tipoContrato.MontoMensual = model.MontoMensual;
            return Json(tipoContrato, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AgregarMes(string sfecha)
        {
            DateTime fecha = new DateTime();
            if (sfecha != "")
            {
                fecha = Convert.ToDateTime(sfecha);
                fecha = fecha.AddMonths(1);
                string dia, mes;
                if (fecha.Day < 10)
                {
                    dia = "0" + fecha.Day;
                }
                else
                {
                    dia = fecha.Day.ToString();
                }
                if (fecha.Month < 10)
                {
                    mes = "0" + fecha.Month;
                }
                else
                {
                    mes = fecha.Month.ToString();
                }
                sfecha = dia + "/" + mes + "/" + fecha.Year;
            }
            return Json(sfecha, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
            DateTime hoy = new DateTime();
            hoy = DateTime.Now;
            hoy.AddMonths(1);

        }

        //
        // GET: /Contrato/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Contrato/Create

        public ActionResult Create()
        {
            tbContrato contrato = new tbContrato();
            contrato.idCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).IdCliente;
            ViewBag.TipoContrato = new SelectList(TipoContratoServicio.ObtenerLista(), "IdTipoContrato", "IdTipoContrato", "");
            ViewBag.UlTipoContrato = TipoContratoServicio.ObtenerLista();
            return View(contrato);
        }

        //
        // POST: /Contrato/Create

        [HttpPost]
        public ActionResult Create(tbContrato collection)
        {
            collection.NombreCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).Nombre;
            collection.idCliente = ClienteServicio.ObtenerPorCorreo(HttpContext.User.Identity.Name).IdCliente;
            ViewBag.TipoContrato = new SelectList(TipoContratoServicio.ObtenerLista(), "IdTipoContrato", "IdTipoContrato", collection.tipo);
            collection.Monto = TipoContratoServicio.ObtenerMontoMensual(Convert.ToInt32(collection.tipo)).MontoMensual;
            ContratoServicio.Crear(collection);
            return View("../Cliente/Index");
        }

        //
        // GET: /Contrato/Edit/5

        public ActionResult Edit(int id)
        {


            return View();
        }

        //
        // POST: /Contrato/Edit/5

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
        // GET: /Contrato/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Contrato/Delete/5

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
