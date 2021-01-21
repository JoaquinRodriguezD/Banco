using Banco.Filters;
using Banco.Models;
using Banco.Models.TableViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bitacora
        public ActionResult Bitacora()
        {
            List<BitacoraTableViewModel> lst = null;
            using (BancoEntities banco = new BancoEntities())
            {
                lst = (from d in banco.bitacora
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
            return View();
        }

        // POST: Deposito
        [HttpPost]
        public ActionResult Deposito(int ide, int sal)
        {
            BancoEntities banco = new BancoEntities();
            //ide = int.Parse((String)Session["no_cuenta"]);
            banco.deposito(ide, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Retiro
        public ActionResult Retiro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Retiro(int ide, int sal)
        {
            BancoEntities banco = new BancoEntities();
            banco.retiro(ide, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transferencia
        public ActionResult Transferencia()
        {
            return View();
        }
        // POST: Transferencia
        [HttpPost]
        public ActionResult Transferencia(int ide, int ide2, int sal)
        {
            BancoEntities banco = new BancoEntities();
            banco.transferencia(ide, ide2, sal);
            banco.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}