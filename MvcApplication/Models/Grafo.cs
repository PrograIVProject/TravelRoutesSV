using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Models;

namespace MvcApplication.Models
{
    public class Grafo
    {
        
        public static Arista[,] getMatrizAdyacencia()
        {
            var _db = new travelEntities();
            var nodos = _db.Destinos.ToList();
            var n = nodos.Count;
            Arista[,] matriz = new Arista[n, n];
            for (var i = 0; i < n; i++ ){
                for (var j = 0; j < n; j++) {
                    var IdDestinoInicial = nodos[i].Id;
                    var IdDestinoFinal = nodos[j].Id;
                    var arista = _db.Aristas.SingleOrDefault(a => a.IdDestinoInicial == IdDestinoInicial && a.IdDestinoFinal == IdDestinoFinal);
                    matriz[i, j] = arista;
                }
            }
            return matriz;
        }
    }
}