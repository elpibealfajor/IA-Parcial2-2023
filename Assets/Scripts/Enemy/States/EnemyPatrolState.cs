using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState<T> : EnemyStateBase<T>
{
    T input;
    public EnemyPatrolState(T input)
    {
        this.input = input;
    }
    public override void Awake()
    {
        base.Awake();
    }
    public override void Execute()
    {
        base.Execute();
        if (model.transform.position != model.wPoints[model.current].position)
        {
            model.Patrol(model.wPoints[model.current].position);
            model.LookDirPatrol(model.wPoints[model.current]);
            Debug.Log("patrullando");
        }
        else
        {
            model.current = (model.current + 1) % model.wPoints.Length;
        }

    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
