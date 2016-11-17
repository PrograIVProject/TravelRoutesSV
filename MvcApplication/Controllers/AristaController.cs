using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class AristaController : Controller
    {
        private readonly travelEntities _db = new travelEntities();
        public JsonResult GetAll()
        {
            try
            {
                var aristas = _db.Aristas.Select(a => new { Id = a.Id, x1 = a.DestinoInicial.Coordenada_X, y1 = a.DestinoInicial.Coordenada_Y, x2 = a.DestinoFinal.Coordenada_X, y2 = a.DestinoFinal.Coordenada_Y, Distancia = a.Distancia, Descripcion = a.Descripcion}).ToList();
                return Json(new { success = true, aristas = aristas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
        public JsonResult GetById(int id)
        {
            try
            {
                var arista = _db.Aristas.Where(a => a.Id == id).Select(a => new { Id = a.Id, x1 = a.DestinoInicial.Coordenada_X, y1 = a.DestinoInicial.Coordenada_Y, x2 = a.DestinoFinal.Coordenada_X, y2 = a.DestinoFinal.Coordenada_Y, Distancia = a.Distancia, Descripcion = a.Descripcion }).SingleOrDefault();
                return Json(new { success = true, arista = arista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
        [HttpPost]
        public JsonResult Save(Arista arista)
        {
            try
            {
                _db.Aristas.Add(arista);
                _db.SaveChanges();
                return this.GetById(arista.Id);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }


        }

    }
}
