using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float numerito1;
    public float numerito2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var sumita = numerito1 + numerito2;
            Debug.Log(sumita);
        }
    }
}
