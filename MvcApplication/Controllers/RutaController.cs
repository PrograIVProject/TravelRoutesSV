using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class RutaController : Controller
    {
        //
        // GET: /Ruta/

        public JsonResult Get(int IdDestinoInicial, int IdDestinoFinal) {
            try {
                var matriz = Grafo.getMatrizAdyacencia();
                var recorrido = Dijkstra.DijkstraAlgorithm(matriz, IdDestinoInicial, IdDestinoFinal);
                if (recorrido == null) {
                    return Json(new { success = false, message ="No existe camino entre los destinos seleccionados." }, JsonRequestBehavior.AllowGet);
                }
                
                return Json(new { recorrido = recorrido.Select(d => new { Nombre = d.Nombre, Descripcion = d.Descripcion }) }, JsonRequestBehavior.AllowGet);
            }catch(Exception ex){
                    return Json(new {success = false, message = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Index()
        {
            
            
            return View();
        }

    }
}
