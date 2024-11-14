using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float verticalSpeed;
    public float turnSpeed;
    public float jumpForce;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    private Rigidbody playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * verticalSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SummonFireball();
        }
    }

    void SummonFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Rigidbody fireballRB = fireball.GetComponent<Rigidbody>();

            if (fireballRB != null)
            {
                fireballRB.useGravity = false;
                Debug.DrawRay(fireballSpawnPoint.position, fireballSpawnPoint.forward * 10f, Color.red, 1f);
                fireballRB.AddForce(fireballSpawnPoint.forward * 100f, ForceMode.Impulse);
            }
        }
    }
}


