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
    public class PagoServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        public tbContrato MontoMensual(int montomensual)
        {
            return (from m in db.tbContrato where m.IdContrato == montomensual select m).FirstOrDefault();
        }

        public string Crear(tbPagos pagos)
        {
            try
            {

                db.tbPagos.Attach(pagos);
                db.Entry(pagos).State = EntityState.Added;
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