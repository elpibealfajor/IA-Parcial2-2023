using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyController : MonoBehaviour
{
    public float lifeTime;
    public float range;
    private void Awake()
    {
        CheckCollision();
        Destroy(gameObject, lifeTime);
    }
    private void CheckCollision()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, range);
        foreach (Collider col in collider)
        {
            if (col.gameObject.tag == "Enemy")
            {
                var enemyControler = col.GetComponent<EnemyController>();
                enemyControler.decoy = this.transform;               
                print("detecte un enemigo");
            }
        }
    }
}
