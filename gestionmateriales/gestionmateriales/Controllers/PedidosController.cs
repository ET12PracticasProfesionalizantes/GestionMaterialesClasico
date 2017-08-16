﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class PedidosController : Controller
    {
        pp67_gestionmaterialesEntities db = new pp67_gestionmaterialesEntities();
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }
        // GET: Pedido/Agregar
        public ActionResult Agregar()
        {
            return View();
        }
        //POST: Pedido/1/Agregar
        [HttpPost]
        public ActionResult Agregar(pedido unPedido)
        {
            try
            {
                db.pedido.Add(new pedido { nroPedido = unPedido.nroPedido, nroOrdenDeTrabajo = unPedido.nroOrdenDeTrabajo, destino = unPedido.destino });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Pedidos");
            }

            return RedirectToAction("Agregar", "Pedidos");
        }
        //GET: Pedidos/Editar/1
        public ActionResult Editar(int id)
        {
            pedido pedidoSeleccionado;

            try
            {
                pedidoSeleccionado = db.pedido.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Pedidos");
            }

            return View(pedidoSeleccionado);
        }
        //POST: Personal/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, pedido unPedido)
        {
            pedido nuevoPedido = db.pedido.Find(id);
            try
            {
                nuevoPedido.nroPedido = unPedido.nroPedido;
                nuevoPedido.nroOrdenDeTrabajo = unPedido.nroOrdenDeTrabajo;
                nuevoPedido.destino = unPedido.destino;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Pedidos");
            }

            return RedirectToAction("Buscar", "Pedidos");
        }
        // GET: Pedido/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.nroPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroPedido_asc" : "";
            ViewBag.nroPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroPedido_desc" : "";
            ViewBag.nroOrdenDeTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenDeTrabajo_asc" : "";
            ViewBag.nroOrdenDeTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenDeTrabajo_desc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<pedido> staff = db.pedido.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //TODO
                staff = db.pedido.Where(s => s.nroPedido.ToString().Contains(searchString.ToUpper()) || s.nroOrdenDeTrabajo.ToString().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nroPedido_asc":
                    staff = staff.OrderBy(s => s.nroPedido).ToList();
                    break;
                case "nroPedido_desc":
                    staff = staff.OrderByDescending(s => s.nroPedido).ToList();
                    break;
                case "nroOrdenDeTrabajo_asc":
                    staff = staff.OrderBy(s => s.nroOrdenDeTrabajo).ToList();
                    break;
                case "nroOrdenDeTrabajo_desc":
                    staff = staff.OrderByDescending(s => s.nroOrdenDeTrabajo).ToList();
                    break;
            }

            return View(staff.ToList());
        }
    }
}