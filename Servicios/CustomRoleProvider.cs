using ServiExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Security;
using System.Text;


namespace ServiExpress.Servicios
{
    public class CustomRoleProvider : RoleProvider
    {
        ServicioDeEntregasEntities db = new ServicioDeEntregasEntities();
        public override string ApplicationName { get; set; }

        public override bool IsUserInRole(string id, string roleName)
        {
            //try
            //{
            //    using (var db = new ServicioDeEntregasEntities())
            //    {
                    var userC = db.tbClientes.Find(int.Parse(id));
                    var userR = db.tbRepartidor.Find(int.Parse(id));

                    if (userC == null && userR == null)
                    {
                        return false;
                    }
                    else
                    {
                        var rol = (from r in db.tbRoles where roleName == r.Nombre select r).FirstOrDefault();
                        if (rol == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (userC != null)
                            {
                                if (userC.tbRoles.idRol == rol.idRol)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (userR.tbRoles.idRol == rol.idRol)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                        }
                    }
            //    }
            //}
            //catch (Exception)
            //{
            //    return false;
            //}




        }

        public override string[] GetRolesForUser(string username)
        {
            int nombreUsuario = Convert.ToInt32(username);
            //using (var db = new ServicioDeEntregasEntities())
            //{
                var userC = db.tbClientes.SingleOrDefault(u => u.IdCliente == nombreUsuario);
                var userR = db.tbRepartidor.SingleOrDefault(c => c.IdRepartidor == nombreUsuario);
                if (userC == null && userC == null)
                {
                    return new string[] { };
                }
                else
                {
                    if (userC != null)
                        return new string[] { userC.tbRoles.Nombre };
                    else
                        return new string[] { userR.tbRoles.Nombre };

                }
            //}
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

    }
}