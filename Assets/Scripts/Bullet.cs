using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            //SceneManager.LoadScene("Example_01");
            Debug.Log("colisione con jugador");
        }
    }
}
