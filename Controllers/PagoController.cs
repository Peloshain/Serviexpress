using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiExpress.Servicios;
using ServiExpress.Models;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.IO; 

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

        WebResponse response;
        public async Task<bool> Envio(string CardNumber, string ExpirationDate, string SecurityCode, string Token, int Amount)
        {
            Pago pago = new Pago();
            var request = (HttpWebRequest)WebRequest.Create("http://189.170.144.90:8080/api/Transaction");

            pago.CardNumber = CardNumber;
            pago.ExpirationDate = ExpirationDate;
            pago.SecurityCode = SecurityCode;
            pago.Token = Token;
            pago.Amount = Amount;

            var userData = new JavaScriptSerializer().Serialize(pago);
            var data = Encoding.ASCII.GetBytes(userData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                response = request.GetResponse();
                Stream datastream = response.GetResponseStream();
                StreamReader reader = new StreamReader(datastream);
                String responseFromServer = reader.ReadToEnd();
                //return Json("listo", JsonRequestBehavior.AllowGet);
                return true;
            }
            catch (System.Net.WebException ex)
            {
                //return Json("mal", JsonRequestBehavior.AllowGet); ;
                return false;
            }

        }

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
