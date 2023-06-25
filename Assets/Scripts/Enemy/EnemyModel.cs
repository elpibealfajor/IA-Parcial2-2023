using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public float range;
    public float angle = 120f;
    public LayerMask layerMask;
    public float speed;
    public float chaseSpeed;

    //patrolling
    public Transform[] wPoints;
    public int current;

    //Vision of the player
    public Transform target;

    //decoy
    public Transform decoy;
    private void Awake()
    {

    }
    void Start()
    {
        current = 0;
    }
    public void Chase(Vector3 playerPosition, Transform player)
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition
            , chaseSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
    public void DecoyDistracted()
    {
        // wait a few seconds and then again to patrol
        Invoke(nameof(Patrol),5f); 
    }
    public void Patrol(Vector3 currentWaypointPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypointPosition, speed * Time.deltaTime);
    }
    public void LookDirPatrol(Transform currentWaypointTransform)
    {
        transform.LookAt(currentWaypointTransform);
    }
    
    public bool IsInRange(Transform target)
    {
        // lo mismo que hacer b-a
        float distance = Vector3.Distance(transform.position,target.position);

        if (distance > range)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsInAngle(Transform target)
    {
        Vector3 foward = transform.forward;
        Vector3 dirToTarget = (target.position - transform.position);
        float angleToTarget = Vector3.Angle(foward, dirToTarget);
        if (angle/2 > angleToTarget)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool IsInVision(Transform target)
    {
        Vector3 diff = (target.position - transform.position);
        Vector3 dirToTarget = diff.normalized;
        float distanceToTarget = diff.magnitude;

        RaycastHit hit;

        if (Physics.Raycast(transform.position,dirToTarget,out hit,distanceToTarget,layerMask))
        {
            return false;
        }
        return true;
    }
    public bool GetIfTargetIsViewed()
    {
        if (IsInRange(target) && IsInAngle(target) && IsInVision(target))
        {
            //model.Chase(target.position, target);
            return true;
            //print("dentro del rango de vision");
        }
        else
        {
            return false;
        }
        //else if (decoy != null && model.IsInRange(decoy) && model.IsInAngle(decoy) && model.IsInVision(decoy))
        //{
        //    print("decoy en rango de vision");
        //}
        //else
        //{
        //    print("fuera de vision");
        //}
    }
    public void SetEyesVisuals()
    {
        //efectos visuales al estar en vision
    }
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0,-angle / 2, 0) * transform.forward * range);

    }
}
