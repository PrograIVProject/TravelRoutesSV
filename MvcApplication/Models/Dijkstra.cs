using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Dijkstra
    {
        private static int? getIndexByIdDestino(int Id)
        {
            if (Id == -1) return null;
            var _db = new travelEntities();
            var destinos = _db.Destinos.OrderBy(d => d.Id).ToList();
            var n = destinos.Count;
            for (int i = 0; i < n; i++) {
                if (destinos[i].Id == Id) {
                    return i;
                }
            }
            return 0;
        }
        public static List<Destino> DijkstraAlgorithm(Arista[,] graph, int IdDestinoInicial, int IdDestinoFinal)
        {
            var _db = new travelEntities();
            var destinos = _db.Destinos.OrderBy(d => d.Id).ToList();

            var n = graph.GetLength(0);

            var distance = new Decimal[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = Decimal.MaxValue;
                
            }
            distance[getIndexByIdDestino(IdDestinoInicial).Value] = 0;
            

            var used = new bool[n];
            var previous = new int?[n];

            while (true)
            {
                var minDistance = Decimal.MaxValue;
                var minNode = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minDistance > distance[i])
                    {
                        minDistance = distance[i];
                        minNode = i;
                    }
                }

                if (minDistance == Decimal.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] != null && graph[minNode, i].Distancia > 0)
                    {
                        var shortestToMinNode = distance[minNode];
                        var distanceToNextNode = graph[minNode, i].Distancia;

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[i])
                        {
                            distance[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[getIndexByIdDestino(IdDestinoFinal).Value] == Decimal.MaxValue)
            {
                return null;
            }

            var path = new LinkedList<Destino>();
            int? currentNode = getIndexByIdDestino(IdDestinoFinal);
            while (currentNode != null)
            {
                path.AddFirst(destinos[currentNode.Value]);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }
    }
}