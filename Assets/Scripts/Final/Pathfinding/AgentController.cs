using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Entity model;
    public Node goalNode;
   
    public float radius;
    public LayerMask mask;
    public LayerMask maskObstacle;

    Collider[] _colliders;

    BFS<Node> _bfs;
    DFS<Node> _dfs;
    Dijkstra<Node> _dijkstra;
    AStar<Node> _aStar;
    ThetaStar<Node> _theta;

    public Node start;

    private void Awake()
    {
        _bfs = new BFS<Node>();
        _dfs = new DFS<Node>();
        _dijkstra = new Dijkstra<Node>();
        _aStar = new AStar<Node>();
        _theta = new ThetaStar<Node>();

        _colliders = new Collider[10];
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BFSRun();
            Debug.Log("se corrio BFS");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DFSRun();
            Debug.Log("se corrio DFS");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DijkstraRun();
            Debug.Log("se corrio Dijkstra");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AStarRun();
            Debug.Log("se corrio AStar");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ThetaStarRun();
            Debug.Log("se corrio ThetaStar");
        }
    }

    public void BFSRun()
    {
        var start = GetStartNode();
        if (start == null) return;

        var path = _bfs.Run(start,Satisfies, GetConnections);

        model.SetWayPoints(path);
    }
    public void DFSRun()
    {
        var start = GetStartNode();
        if (start == null) return;

        var path = _dfs.Run(start, Satisfies, GetConnections);

        model.SetWayPoints(path);
    }
    public void AStarRun()
    {
        var start = GetStartNode();
        if (start == null) return;

        var path = _aStar.Run(start, Satisfies, GetConnections,GetCost,GetHeuristic);

        model.SetWayPoints(path);
    }
    public void DijkstraRun()
    {
        var start = GetStartNode();
        if (start == null) return;

        var path = _dijkstra.Run(start, Satisfies, GetConnections, GetCost);

        model.SetWayPoints(path);
    }
    public void ThetaStarRun()
    {
        var start = GetStartNode();
        if (start == null) return;

        var path = _theta.Run(start, Satisfies, GetConnections, GetCost, GetHeuristic,InView);

        model.SetWayPoints(path);
    }
    bool InView(Node from, Node to) // from=abuelo  -   to=nieto
    {
        //RaycastHit hit;
        if (Physics.Linecast(from.transform.position,to.transform.position, maskObstacle))
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
    float GetCost(Node parent, Node son)
    {
        //float para la relevancia de los costos
        float multiplierDistance = 1;
        float multiplierEnemyInNode = 20;
        //como calculamos el costo de la conexcshion aca
        float cost = 0;
        //por distancia
        cost += Vector3.Distance(parent.transform.position, son.transform.position) + multiplierDistance;
        if (son.hasEnemy)
        {
            cost += multiplierEnemyInNode;
        }
        return cost;
    }
    float GetHeuristic(Node curr)
    {
        float multiplierDistance = 2;
        float cost = 0;

        //por distancia
        cost += Vector3.Distance(curr.transform.position, goalNode.transform.position) + multiplierDistance;

        return cost;
    }
    List<Node> GetConnections(Node curr)
    {
        return curr.neightbourds;
    }
    
    bool Satisfies(Node curr)
    {
        return curr == goalNode;
    }
    
    Node GetStartNode()
    {
        //Collider[] objs = Physics.OverlapSphere(model.position, radius, mask);
        int count = Physics.OverlapSphereNonAlloc(model.transform.position, radius, _colliders, mask); //reusa el array
        float bestDistance = 0;
        Collider bestCollider = null;
        for (int i = 0; i < count; i++)
        {
            Collider currColl = _colliders[i];
            float currDistance = Vector3.Distance(model.transform.position, currColl.transform.position);
            //chequeamos si el nodo que estamos analizando esta mas cerca que el actual, el primero es null
            if (bestCollider == null || bestDistance > currDistance)
            {
                bestDistance = currDistance;
                bestCollider = currColl;
            }
        }
        if (bestCollider != null)
        {
            return bestCollider.GetComponent<Node>();
        }
        else
        {
            return null;
        }
    }
}
