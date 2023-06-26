using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState<T> : EnemyStateBase<T>
{
    T input;
    public EnemyChaseState(T input)
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
        model.Chase(model.target.position, model.target);
    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
