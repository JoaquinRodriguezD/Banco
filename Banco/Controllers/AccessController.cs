using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Banco.Filters;
using Banco.Models;

namespace Banco.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(int No_cuenta, int Nip)
        {
            try
            {
                using (BancoEntities banco = new BancoEntities())
                {
                    var lst = from d in banco.cuenta
                              where d.no_cuenta == No_cuenta && d.nip == Nip
                              select d;
                    if (lst.Count() > 0)
                    {
                        cuenta oUser = lst.First();
                        Session["user"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Datos invalidos");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

        // GET: CreateCliente
        public ActionResult CreateCliente()
        {
            return View();
        }

        // POST: CreateCliente
        [HttpPost]
        public ActionResult CreateCliente(string nom_cliente, string a_paterno, string a_materno, string telefono, DateTime fecha_nacimiento, int nip)
        {
            BancoEntities db = new BancoEntities();
            db.ingresar_cliente(nom_cliente, a_paterno, a_materno, telefono, fecha_nacimiento, nip);
            db.SaveChanges();

            var lst = from d in db.cliente
                      where d.nom_cliente == nom_cliente && d.a_paterno == a_paterno
                      && d.a_materno == a_materno && d.telefono == telefono
                      && d.fecha_nacimiento == fecha_nacimiento
                      select d;
            try
            {
                cliente oUser = lst.First();
                Session["cliente_nuevo"] = oUser;
            }
            catch(Exception e)
            {
                Console.WriteLine("error" + e);
            }

            return RedirectToAction("Details", "Access");
        }

        //GET Detalles de nuevo cliente
        public ActionResult Details()
        {
            BancoEntities db = new BancoEntities();
            var oUser = (cliente)HttpContext.Session["cliente_nuevo"];
            int? id = oUser.id_cliente;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
    }
}