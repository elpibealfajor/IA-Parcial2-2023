using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    EnemyModel model;
    private void Awake()
    {
        model = GetComponent<EnemyModel>();
    }
    void Start()
    {
        
    }
    void Update()
    {
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
