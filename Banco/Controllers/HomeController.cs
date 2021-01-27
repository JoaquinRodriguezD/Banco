using Banco.Filters;
using Banco.Models;
using Banco.Models.TableViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Banco.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoEntities banco = new BancoEntities();
        public ActionResult Index()
        {
            BancoEntities db = new BancoEntities();
            var oUser = (cuenta)HttpContext.Session["user"];
            var lst2 = from d in db.cuenta
                       where d.no_cuenta == oUser.no_cuenta
                       select d;
            cuenta oUseraux2 = lst2.First();
            var lst = from d in db.cliente
                      where d.no_cuenta == oUser.no_cuenta
                      select d;
            cliente oUseraux = lst.First();
            int? id = oUseraux.id_cliente;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.fecha = oUseraux.fecha_nacimiento.ToString("dd/MM/yyyy");
            ViewBag.Nombre = oUseraux.nom_cliente;
            ViewBag.saldo = oUseraux2.saldo;
            return View(cliente);
        }

        // GET: Bitacora
        public ActionResult Bitacora()
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            int aux = oUser.no_cuenta;
            List<BitacoraTableViewModel> lst = null;
            using (BancoEntities banco = new BancoEntities())
            {
                lst = (from d in banco.bitacora
                       where d.no_cuenta == aux
                       orderby d.fecha_hora
                       select new BitacoraTableViewModel
                       {
                           Tipo = d.tipo,
                           Fecha_hora = d.fecha_hora,
                           Monto = d.monto,
                           Estado = d.estado
                       }).ToList();
            }

            return View(lst);
        }

        // GET: Deposito
        public ActionResult Deposito()
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            ViewBag.num = oUser.no_cuenta;
            return View();
        }

        // POST: Deposito
        [HttpPost]
        public ActionResult Deposito(int sal)
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            int ide = oUser.no_cuenta;
            banco.deposito(ide, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Retiro
        public ActionResult Retiro()
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            ViewBag.num = oUser.no_cuenta;
            return View();
        }
        // POST: Retiro
        [HttpPost]
        public ActionResult Retiro(int sal)
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            int ide = oUser.no_cuenta;
            banco.retiro(ide, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transferencia
        public ActionResult Transferencia()
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            ViewBag.num = oUser.no_cuenta;
            return View();
        }
        // POST: Transferencia
        [HttpPost]
        public ActionResult Transferencia(int ide2, int sal)
        {
            var oUser = (cuenta)HttpContext.Session["user"];
            int ide = oUser.no_cuenta;
            banco.transferencia(ide, ide2, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}