using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThetaStar<T>
{
    //delegate bool isNodeSatisfactory(T node);

    public List<T> Run(T start, Func<T, bool> isNodeSatisfactory, Func<T, List<T>> connections,
        Func<T, T, float> getCost, Func<T, float> heuristic, Func<T,T, bool> inView,int watchdog = 1000)
    {
        PriorityQueue<T> pending = new PriorityQueue<T>(); //usamos queue en vez de lista porque saca el que ingresamos primero
        HashSet<T> visited = new HashSet<T>(); //diccionario pero sin value, solo sirve para ver si hay algo dentro de el sin devolver nada                                   
        Dictionary<T, T> parent = new Dictionary<T, T>();
        Dictionary<T, float> cost = new Dictionary<T, float>();

        pending.Enqueue(start, 0);
        cost[start] = 0;
        while (!pending.IsEmpty)
        {
            Debug.Log("Theta while");
            #region //analizamos que no supere el watchdog
            watchdog--;
            if (watchdog <= 0)
            {
                break;
            }
            #endregion
            var curr = pending.Dequeue();
            if (isNodeSatisfactory(curr))
            {
                var path = new List<T>();
                path.Add(curr);

                while (parent.ContainsKey(path[path.Count - 1])) //si el ultimo de la lista tiene padre lo agrega
                {
                    var father = parent[path[path.Count - 1]];
                    path.Add(father);
                }
                path.Reverse();
                return path;
            }
            visited.Add(curr);
            var neightbourds = connections(curr);
            for (int i = 0; i < neightbourds.Count; i++)
            {
                var neigh = neightbourds[i];
                if (visited.Contains(neigh))
                {
                    continue;
                }
                T realParent = curr;
                if (parent.ContainsKey(curr) && inView(parent[curr],neigh)) //si el abuelo ve al nieto xd, preguntamos si tiene un padre para que no null
                {
                    realParent = parent[curr];
                }
                float tentativeCost = cost[realParent] + getCost(realParent, neigh); // cur padre neigh padre
                if (cost.ContainsKey(neigh) && cost[neigh] > tentativeCost)
                {
                    continue;
                }
                pending.Enqueue(neigh, tentativeCost + heuristic(neigh));
                parent[neigh] = realParent;
                cost[neigh] = tentativeCost;
            }
        }
        return new List<T>(); //para que no rompa
        //return null;
    }
}
