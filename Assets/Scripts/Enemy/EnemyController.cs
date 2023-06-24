using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    FSM<EnemyStates> fsm;
    List<EnemyStateBase<EnemyStates>> states;
    //patrolling
    public Transform[] wPoints;
    int current;
    //public float speed;

    //Vision of the player
    public Transform target;
    EnemyModel model;
    private void Awake()
    {
        model = GetComponent<EnemyModel>();
        //InitializedFSM();
    }
    void InitializedFSM()
    {
        //fsm = new FSM<EnemyStates>();
        //var chase = new EnemyChaseState<EnemyStates>(EnemyStates.Patroling);
        //var patrol = new EnemyPatrolState<EnemyStates>(EnemyStates.chase);

        //states.Add(chase);
        //states.Add(patrol);

        //chase.AddTransition(EnemyStates.Patroling, patrol);
        //patrol.AddTransition(EnemyStates.chase, chase);

        //for (int i = 0; i < states.Count; i++)
        //{
        //    states[i].InitializedState(model);
        //}

        //fsm.SetInit(patrol);
    }

    void Start()
    {
        current = 0;
    }
    void Update()
    {
        //fsm.OnUpdate();

        if (transform.position != wPoints[current].position)
        {
            //transform.position = Vector3.MoveTowards(transform.position, wPoints[current].position, speed * Time.deltaTime);
            //transform.LookAt(wPoints[current]);
            model.Patrol(wPoints[current].position);
            model.LookDirPatrol(wPoints[current]);
        }
        else
        {
            current = (current + 1) % wPoints.Length;
        }


        if (model.IsInRange(target) && model.IsInAngle(target) && model.IsInVision(target))
        {
            //model.Chase(target.position, target);
            print("dentro del rango de vision");
        }
        else
        {
            print("fuera de la vision");
        }
    }
}
