using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    private float xInput;
    private float zInput;

    public GameObject decoy;
    public float decoyCooldownTime;
    private float decoyCooldown = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInputs();
        DecoySpawn();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);        
    }
    private void DecoySpawn()
    {
        decoyCooldown = decoyCooldown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && decoyCooldown <= 0)
        {
            Instantiate(decoy,transform.position,transform.rotation);
            decoyCooldown = decoyCooldownTime;
        }
        else
        {
            return;
        }
    }
}
