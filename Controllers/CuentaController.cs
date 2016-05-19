using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiExpress.Servicios;
using ServiExpress.Models;
using System.Web.Security;
using ServiExpress.Models;

namespace ServiExpress.Controllers
{
    public class CuentaController : Controller
    {
        private ClienteServicio clienteServicio = new ClienteServicio();
        private RepartidorServicio repartidorServicio = new RepartidorServicio();
        
        // GET: /Cuenta/


        public ActionResult LogIn()
        {
            return View();
        }

        //
        // POST: /Cuenta/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Usuario usuario)
        {
            var c = clienteServicio.BuscarCliente(usuario);
            if(c!=null)
            {
                DateTime expira = DateTime.Now.AddDays(1);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, c.Correo, DateTime.Now, expira, true, c.Nombre, FormsAuthentication.FormsCookiePath);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                    FormsAuthentication.Encrypt(ticket));
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                
                HttpCookie Rol = new HttpCookie("Rol", c.tbRoles.Nombre );
                Rol.Expires = expira;
                Response.Cookies.Add(Rol);

                Session["Rol"] = c.tbRoles.Nombre;


;
                return RedirectToAction("Index","Home");

            }
            var r = repartidorServicio.BuscarRepartidor(usuario);
            if(r!=null)
            {
                    DateTime expira = DateTime.Now.AddMinutes(30);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, r.Correo.ToString(), DateTime.Now, expira, true, r.Nombre, FormsAuthentication.FormsCookiePath);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(ticket));
                    cookie.Expires = ticket.Expiration;
                    Response.Cookies.Add(cookie);

                    HttpCookie Rol = new HttpCookie("Rol", r.tbRoles.Nombre);
                    Rol.Expires = expira;
                    Response.Cookies.Add(Rol);

                    Session["Rol"] = r.tbRoles.Nombre;

                    return RedirectToAction("Index","Home");

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["Rol"] = null;
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Cuenta/Edit/5

        public ActionResult Edit(int id)
        {
            var usuario = User.Identity.Name;
            var cliente = clienteServicio.ObtenerPorCorreo(usuario);
            return View();
        }

        //
        // POST: /Cuenta/Edit/5

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
        // GET: /Cuenta/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cuenta/Delete/5

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
