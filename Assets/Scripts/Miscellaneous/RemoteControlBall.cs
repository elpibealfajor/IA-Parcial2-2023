using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlBall : MonoBehaviour
{
    public Transform target;
    Isteering steering;

    RemoteBallModel remoteBall;
    public float lifeTime;
    public float range;


    private void Awake()
    {
        remoteBall = GetComponent<RemoteBallModel>();
        CheckCollision();
        Destroy(gameObject, lifeTime);
        InitializeSteering();       
    }
    private void Start()
    {

    }
    private void CheckCollision()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, range);
        foreach (Collider col in collider)
        {
            if (col.gameObject.tag == "Enemy")
            {
                var enemyModel = col.GetComponent<EnemyModel>();
                target = enemyModel.transform;
            }
        }
    }
    void InitializeSteering()
    {
        var seek = new Seek(transform, target.transform);
        steering = seek;
    }
    private void Update()
    {
        Vector3 dir = steering.GetDir();
        remoteBall.Move(dir);
        remoteBall.LookDir(dir);
    }
}
