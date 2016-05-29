using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using ServiExpress.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace ServiExpress.Servicios
{
     
    public class EntregaServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        public List<tbEntregas> ObtenerLista()
        {
            return (from o in db.tbEntregas select o).ToList();
        }

        public tbEntregas ObtenerPorOrden(int idorden)
        {
            return (from o in db.tbEntregas where o.idOrden == idorden select o).FirstOrDefault();
        }

        public tbEntregas ObtenerOrdenPorIdCliente(int idCliente)
        {
            return (from o in db.tbEntregas where o.idCliente == idCliente select o).FirstOrDefault();
        }
         public string Crear(tbEntregas entrega)
        {
            try
            {

                db.tbEntregas.Attach(entrega);
                db.Entry(entrega).State = EntityState.Added;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
    }
}
}