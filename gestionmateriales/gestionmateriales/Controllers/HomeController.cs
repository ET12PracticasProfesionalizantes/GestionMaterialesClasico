﻿using System.Web.Mvc;
using System.Linq;
using gestionmateriales.Models;
using System.Collections.Generic;
using gestionmateriales.Models.OficinaTecnica;

namespace gestionmateriales.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Notificacion = 0;
            if (hayMaterialParaComprar())
                ViewBag.Notificacion = 1;
            return View("Index");
        }

        [HttpGet]
        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        private dynamic hayMaterialParaComprar()
        {
            bool notif = false;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                notif = db.materiales.Any(y => y.hab && y.stockActual <= y.stockMinimo);
            }
            return notif;
        }

        public ActionResult Menu()
        {
            List<MenuItem> menu = new List<MenuItem>();

            if (User.IsInRole("administrador"))
            {
                menu.Add(new MenuItem { Id = 10, nameOption = "Documentos", controller = "", action = "", imageClass = "fas fa-file-alt", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Trabajo", controller = "OrdenTrabajo", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Trabajo de Aplicación", controller = "OrdenTrabajoAplicacion", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Pedido", controller = "OrdenPedido", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Compra", controller = "OrdenCompra", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "fas fa-sync", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Ingreso", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 22, nameOption = "Egreso", controller = "Stock", action = "Restar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Ingreso", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 24, nameOption = "Historia Egreso", controller = "Stock", action = "HistorialEgresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 30, nameOption = "Compras", controller = "", action = "", imageClass = "fas fa-shopping-cart", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 31, nameOption = "Materiales a Comprar", controller = "Compras", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 30 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Materiales", controller = "Material", action = "Index", imageClass = "fas fa-wrench", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 50, nameOption = "Proveedor", controller = "Proveedor", action = "Index", imageClass = "fas fa-truck", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 60, nameOption = "Personal", controller = "Personal", action = "Index", imageClass = "fas fa-male", estatus = true, isParent = false, parentId = 0 });
            }

            if (User.IsInRole("deposito"))
            {
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "fas fa-sync", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Ingreso", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 22, nameOption = "Egreso", controller = "Stock", action = "Restar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Ingreso", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 24, nameOption = "Historial Egreso", controller = "Stock", action = "HistorialEgresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Material", controller = "Material", action = "Index", imageClass = "fas fa-wrench", estatus = true, isParent = false, parentId = 0 });
            }

            if (User.IsInRole("compras"))
            {
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "fas fa-sync", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Ingreso", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Ingreso", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 30, nameOption = "Compras", controller = "", action = "", imageClass = "fas fa-shopping-cart", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 31, nameOption = "Materiales a Comprar", controller = "Compras", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 30 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Material", controller = "Material", action = "Index", imageClass = "fas fa-wrench", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 50, nameOption = "Proveedor", controller = "Proveedor", action = "Index", imageClass = "fas fa-truck", estatus = true, isParent = false, parentId = 0 });
            }

             return PartialView("Menu", menu);
        }
    }
}