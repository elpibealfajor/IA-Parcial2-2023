using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState<T> : EnemyStateBase<T>
{
    T input;

    public EnemyAttackState(T input)
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
        model.shootTimer += Time.deltaTime;
        //if (model.targetToShoot = model.target)//tambien podemos usar roulete para elegir el siguiente waypoint
        //{
        //    model.Chase(model.target.position, model.target);
        //}
        model.Chase(model.target.position, model.target);

        if (model.shootTimer >= model.shootInterval)
        {
            model.Shoot();
            model.shootTimer = 0f;
        }
    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
