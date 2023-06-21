using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase<T> : State<T>
{
    protected EnemyModel model;

    public void InitializedState(EnemyModel model)
    {
        this.model = model;
    }
}
