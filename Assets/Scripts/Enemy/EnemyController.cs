using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    FSM<EnemyStates> fsm;
    //List<EnemyStateBase<EnemyStates>> states;
    ITreeNode root;
    ////patrolling
    //public Transform[] wPoints;
    //int current;
    //public float speed;

    ////Vision of the player
    //public Transform target;
    EnemyModel model;
    //public Transform decoy;
    private void Awake()
    {
        model = GetComponent<EnemyModel>();
        InitializedFSM();
        InitializedTree();
    }
    public void InitializedFSM()
    {
        var list = new List<EnemyStateBase<EnemyStates>>();
        fsm = new FSM<EnemyStates>();
        var chase = new EnemyChaseState<EnemyStates>(EnemyStates.Patroling);
        var patrol = new EnemyPatrolState<EnemyStates>(EnemyStates.chase);

        list.Add(chase);
        list.Add(patrol);

        chase.AddTransition(EnemyStates.Patroling, patrol);
        patrol.AddTransition(EnemyStates.chase, chase);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].InitializedState(model,fsm);
        }

        patrol.AddTransition(EnemyStates.chase,chase);

        fsm.SetInit(patrol);
    }
    public void InitializedTree()
    {
        //actions
        var patrol = new TreeAction(ActionPatrol);
        var chase = new TreeAction(ActionChase);

        //questions
        var isThePlayer = new TreeQuestion(IsThePlayer,chase,patrol);


        root = isThePlayer;
    }
    bool IsThePlayer()
    {
        return model.GetIfTargetIsViewed();
    }
    void ActionPatrol()
    {
        fsm.Transitions(EnemyStates.Patroling);
    }
    void ActionChase()
    {
        fsm.Transitions(EnemyStates.chase);
    }
    void Start()
    {
        //current = 0;
    }
    void Update()
    {
        fsm.OnUpdate();
        root.Execute();
        //if (transform.position != wPoints[current].position)
        //{
        //    //transform.position = Vector3.MoveTowards(transform.position, wPoints[current].position, speed * Time.deltaTime);
        //    //transform.LookAt(wPoints[current]);
        //    //model.Patrol(wPoints[current].position);
        //    //model.LookDirPatrol(wPoints[current]);
        //}
        //else
        //{
        //    current = (current + 1) % wPoints.Length;
        //}


        //if (model.IsInRange(target) && model.IsInAngle(target) && model.IsInVision(target))
        //{
        //    model.Chase(target.position, target);
        //    print("dentro del rango de vision");

        //}
        //else if (decoy != null && model.IsInRange(decoy) && model.IsInAngle(decoy) && model.IsInVision(decoy))
        //{
        //    print("decoy en rango de vision");
        //}
        //else
        //{
        //    print("fuera de vision");
        //}

    }
}
