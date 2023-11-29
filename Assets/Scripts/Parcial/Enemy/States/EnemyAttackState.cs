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
        enemyController.shootTimer += Time.deltaTime;
        //model.Chase(model.target.position, model.target);
        model.Move(model.target, model.chaseSpeed);

        if (enemyController.shootTimer >= enemyController.shootInterval)
        {
            model.Shoot(enemyController.projectileSpeed);
            enemyController.shootTimer = 0f;
        }
        #region
        //model.shootTimer += Time.deltaTime;
        ////model.Chase(model.target.position, model.target);
        //model.Move(model.target, model.chaseSpeed);

        //if (model.shootTimer >= model.shootInterval)
        //{
        //    model.Shoot();
        //    model.shootTimer = 0f;
        //}
        #endregion
    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
