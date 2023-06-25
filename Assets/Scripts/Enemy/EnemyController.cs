using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    FSM<EnemyStates> fsm;
    ITreeNode root;
    EnemyModel model;
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
        var distracted = new EnemyDistractedState<EnemyStates>(EnemyStates.Distracted);
        

        list.Add(chase);
        list.Add(patrol);
        list.Add(distracted);

        chase.AddTransition(EnemyStates.Patroling, patrol);
        chase.AddTransition(EnemyStates.Distracted, distracted);
        patrol.AddTransition(EnemyStates.chase, chase);
        patrol.AddTransition(EnemyStates.Distracted, distracted);
        distracted.AddTransition(EnemyStates.Patroling, patrol);
        distracted.AddTransition(EnemyStates.chase, chase);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].InitializedState(model,fsm);
        }

        fsm.SetInit(patrol);
    }
    public void InitializedTree()
    {
        //actions
        var patrol = new TreeAction(ActionPatrol);
        var chase = new TreeAction(ActionChase);
        var distracted = new TreeAction(ActionDistracted);

        //questions
        var isTheDecoy = new TreeQuestion(IsDecoy,distracted,patrol);
        var isThePlayer = new TreeQuestion(IsThePlayer,chase,patrol);

        root = isThePlayer;
    }
    bool IsThePlayer()
    {
        return model.GetIfTargetIsViewed();
    }
    bool IsDecoy()
    {
        return model.GetIfDecoyIsViewed();
    }
    void ActionPatrol()
    {
        fsm.Transitions(EnemyStates.Patroling);
    }
    void ActionChase()
    {
        fsm.Transitions(EnemyStates.chase);
    }
    void ActionDistracted()
    {
        fsm.Transitions(EnemyStates.Distracted);
    }
    void Update()
    {
        fsm.OnUpdate();
        root.Execute();
    }
}
