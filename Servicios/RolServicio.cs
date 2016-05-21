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

    public class RolServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        public tbRoles ObtenerRol(int rol)
        {
            return (from r in db.tbRoles where r.idRol == rol select r).FirstOrDefault();
        }

    }
}