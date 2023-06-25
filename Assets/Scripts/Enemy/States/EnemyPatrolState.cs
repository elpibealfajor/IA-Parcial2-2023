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
    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
