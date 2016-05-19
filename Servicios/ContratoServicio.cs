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
    public class ContratoServicio
    {

        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();
        public string Crear(tbContrato contrato)
        {
            try
            {

                db.tbContrato.Attach(contrato);
                db.Entry(contrato).State = EntityState.Added;
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public tbClientes ObtenerCliente(int idcliente)
        {
            var cliente = (from c in db.tbClientes where c.IdCliente == idcliente select c).FirstOrDefault();
            return cliente;
        }

        public tbContrato ObtenerContrato(int idcontrato)
        {
            return (from c in db.tbContrato where c.idCliente == idcontrato select c).FirstOrDefault();
        }

       


    }
}