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
    public class RepartidorServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        public tbRepartidor BuscarRepartidor(Usuario usuario)
        {
            var objrepartidor = (from r in db.tbRepartidor where r.Correo.Equals(usuario.Correo) && r.Contraseña.Equals(usuario.Contraseña) select r).FirstOrDefault();
            return objrepartidor;
        }

        public tbRepartidor ObtenerPorCorreo(string correo)
        {
            return (from r in db.tbRepartidor where r.Correo.Equals(correo) select r).FirstOrDefault();
        }

        public tbRepartidor ObtenerRepartidor(int idcliente)
        {
            var repartidor = (from r in db.tbRepartidor where r.IdRepartidor.Equals(idcliente) select r).FirstOrDefault();
            return repartidor;
        }
    }
}