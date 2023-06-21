using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //patrolling
    public Transform[] wPoints;
    int current;
    public float speed;

    //Vision of the player
    public Transform target;
    EnemyModel model;
    private void Awake()
    {
        model = GetComponent<EnemyModel>();
    }
    void Start()
    {
        current = 0;
    }
    void Update()
    {
        if (transform.position != wPoints[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, wPoints[current].position, speed * Time.deltaTime);
            transform.LookAt(wPoints[current]);
        }
        else
        {
            current = (current + 1) % wPoints.Length;
        }


        if (model.IsInRange(target) && model.IsInAngle(target) && model.IsInVision(target))
        {
            print("dentro del rango de vision");
        }
        else
        {
            print("fuera de la vision");
        }
    }
}
