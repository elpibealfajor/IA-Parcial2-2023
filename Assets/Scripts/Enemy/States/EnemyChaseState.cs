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
    public override void Execute()
    {
        base.Execute();
    }
}
