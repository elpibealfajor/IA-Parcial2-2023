using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase<T> : State<T>
{
    protected EnemyModel model;
    protected EnemyController enemyController;
    protected FSM<T> fsm;

    public void InitializedState(EnemyModel model, FSM<T> fsm, EnemyController enemyController)
    {
        this.model = model;
        this.fsm = fsm;
        this.enemyController = enemyController;
    }
    //public void InitializedState(EnemyModel model, FSM<T> fsm)
    //{
    //    this.model = model;
    //    this.fsm = fsm;
    //}
}
