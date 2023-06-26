using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Isteering
{
    Transform target;
    Transform origin;

    public Seek(Transform origin,Transform target)
    {

        this.target = target;
        this.origin = origin;   
    }
    public Vector3 GetDir()
    {
        return (target.position - origin.position).normalized; //b-a
    }
}
