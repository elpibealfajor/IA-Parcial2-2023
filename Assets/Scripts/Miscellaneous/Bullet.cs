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
        }
        else if (collision.transform.gameObject.tag == "Decoy")
        {
            Destroy(collision.gameObject);
            Debug.Log("Colisione con el decoy");
        }
    }
}
