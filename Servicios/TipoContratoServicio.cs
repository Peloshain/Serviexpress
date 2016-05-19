using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiExpress.Models;

namespace ServiExpress.Servicios
{
    public class TipoContratoServicio
    {
        private ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();


        public tbTipoContrato ObtenerPorID(int id)
        {
            
            return (from t in db.tbTipoContrato where t.IdTipoContrato == id select t).FirstOrDefault();
        }

        public List<tbTipoContrato> ObtenerLista()
        {
            return (from t in db.tbTipoContrato select t).ToList();
        }
             public tbTipoContrato ObtenerMontoMensual(int monto)
        {
            return (from m in db.tbTipoContrato where m.IdTipoContrato == monto select m).FirstOrDefault();
        }
    }
}