using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class DestinoController : Controller
    {
        private readonly ModelContainer _db = new ModelContainer();
        public JsonResult GetAll()
        {
            try {
                var destinos = _db.Destinos.Select(d => new {Id = d.Id, Nombre = d.Nombre, Imagen = d.Imagen, Descripcion = d.Descripcion, Coordenada_X = d.Coordenada_X, Coordenada_Y = d.Coordenada_Y, Tipo = d.Tipo, UsuarioAgrega = d.UsuarioAgrega.Nombre + " " + d.UsuarioAgrega.Apellido }).ToList();
                return Json(new { success = true, destinos = destinos}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, message = ex.Message });
            }
            
        }
        public JsonResult GetById(int id) {
            try
            {
                var destino = _db.Destinos.Where(d => d.Id == id).Select(d => new { Id = d.Id, Nombre = d.Nombre, Imagen = d.Imagen, Descripcion = d.Descripcion, Coordenada_X = d.Coordenada_X, Coordenada_Y = d.Coordenada_Y, Tipo = d.Tipo, UsuarioAgrega = d.UsuarioAgrega.Nombre + " " + d.UsuarioAgrega.Apellido }).SingleOrDefault();
                return Json(new { success = true, destino = destino }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, message = ex.Message });
            }

        }
        [HttpPost]
        public JsonResult Save(Destino destino) {
            try
            {
                _db.Destinos.Add(destino);
                _db.SaveChanges();
                return Json(new { success = true, destino = destino });
            }
            catch (Exception ex) {
                return Json(new { success = true, message = ex.Message});
            }
            
            
        }

    }
}
