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
        #region
        if (enemyController.isRandomPatrollingOn == false)
        {
            if (model.transform.position != enemyController.wPoints[enemyController.current].position)
            {
                model.Move(enemyController.wPoints[enemyController.current], model.speed);
            }
            else
            {
                enemyController.current = (enemyController.current + 1) % enemyController.wPoints.Length;
                model.patrollsCompleted += 1;
            }
        }
        else if (enemyController.isRandomPatrollingOn == true)
        {
            if (model.transform.position != enemyController.currentWaypointTransform.position)
            {
                model.Move(enemyController.currentWaypointTransform, model.speed);
            }
            else
            {
                enemyController.currentWaypointTransform = enemyController.roulette.Run<Transform>(enemyController.dicOfWaypoints);
            }
        }
        #endregion
        #region
        //if (model.isRandomPatrollingOn == false)
        //{
        //    if (model.transform.position != model.wPoints[model.current].position)
        //    {
        //        model.Move(model.wPoints[model.current], model.speed);
        //        //model.Patrol(model.wPoints[model.current].position);
        //        //model.LookDirPatrol(model.wPoints[model.current]);
        //    }
        //    else
        //    {
        //        model.current = (model.current + 1) % model.wPoints.Length;
        //        model.patrollsCompleted += 1;
        //    }
        //}
        //else if (model.isRandomPatrollingOn == true)
        //{
        //    if (model.transform.position != model.currentWaypointTransform.position)
        //    {
        //        model.Move(model.currentWaypointTransform, model.speed);
        //        //model.RandomPatrol(model.currentWaypointTransform);
        //        //model.LookDirPatrol(model.currentWaypointTransform);
        //    }
        //    else
        //    {
        //        model.currentWaypointTransform = model.roulette.Run<Transform>(model.dic);
        //    }
        //}
        #endregion
    }
    public override void Sleep()
    {
        base.Sleep();
    }
}
