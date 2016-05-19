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
    public class ClienteServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();

        public tbClientes BuscarCliente(Usuario usuario)
        {
            var objcliente = (from c in db.tbClientes where c.Correo.Equals(usuario.Correo) && c.Contraseña.Equals(usuario.Contraseña) select c).FirstOrDefault();
            return objcliente;
        }

        public tbClientes ObtenerPorCorreo(string correo)
        {
            return (from c in db.tbClientes where c.Correo.Equals(correo) select c).FirstOrDefault();
        }

        public tbClientes ObtenerCliente(int idcliente)
        {
            var cliente = (from c in db.tbClientes where c.IdCliente == idcliente select c).FirstOrDefault();
            return cliente;
        }

    
        public string Crear(tbClientes cliente)
        {
            try
            {
                cliente.ROL = 1;
                db.tbClientes.Attach(cliente);
                db.Entry(cliente).State = EntityState.Added;
                db.SaveChanges();
                return "";
            }
            catch(Exception ex)
            {
               return ex.Message;
            }
        }

    }
}