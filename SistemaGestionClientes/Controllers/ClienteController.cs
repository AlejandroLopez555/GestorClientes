using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaGestionClientes.Models;

namespace SistemaGestionClientes.Controllers
{
    public class ClienteController : Controller
    {
        private TallerDbContext db = new TallerDbContext();

        //get: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        //get: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //get: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,NombreCompleto,Telefono,Correo,Vehiculo,TipoVehiculo,FechaRegistro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //get: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //post: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,NombreCompleto,Telefono,Correo,Vehiculo,TipoVehiculo,FechaRegistro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Estadisticas()
        {
            var clientes = db.Clientes.ToList();

            //estadisticas 
            ViewBag.TotalClientes = clientes.Count;
            ViewBag.ClientesEsteMes = clientes.Count(c => c.FechaRegistro.Month == DateTime.Now.Month);
            ViewBag.ClientesSemana = clientes.Count(c => c.FechaRegistro >= DateTime.Now.AddDays(-7));

            // Vehiculos mas comunes
            ViewBag.VehiculosComunes = clientes
                .GroupBy(c => c.Vehiculo)
                .Select(g => new { Vehiculo = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            // Registros por mes 
            var seisMesesAtras = DateTime.Now.AddMonths(-6);
            ViewBag.RegistrosPorMes = clientes
                .Where(c => c.FechaRegistro >= seisMesesAtras)
                .GroupBy(c => new { c.FechaRegistro.Year, c.FechaRegistro.Month })
                .Select(g => new {
                    Mes = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMM yyyy"),
                    Count = g.Count()
                })
                .OrderBy(x => x.Mes)
                .ToList();

            return View();
        }

        //get: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //post: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}